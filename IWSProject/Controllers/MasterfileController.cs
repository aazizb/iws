using IWSProject.Content;
using IWSProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class MasterfileController : Controller
    {
        IWSDataContext db;
        public MasterfileController()
        {
            db = new IWSDataContext();
        }
        //// GET: Masterfile
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private object RootFolder = "~/Content/Uploads";

        public ActionResult Masterfile()
        {
            return View("Masterfile", RootFolder);
        }
        [ValidateInput(false)]
        public ActionResult MasterfilePartial(string currentFileName)
        {
            return PartialView("MasterfilePartial", RootFolder);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UploadToDB(string[] files)
        {

            const string articles = "id;name;description;price";

            const string accounts = "id;name;balance;description";

            const string providerXLS = "Provider=Microsoft.ACE.OLEDB.12.0.;Data Source=";
            const string extensionXLS = ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=2\"";
            const string providerXLSX = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            const string extensionXLSX = ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";

            string companyId = (string)Session["CompanyID"];

            //foreach (var item in files)
            //{
            string fullPath = files[0].ToString();
            string msg = string.Empty;
            string option = string.Empty;
            string fileName = fullPath.Substring(fullPath.IndexOf(@"\") + 1);
            if (fileName.Equals(null))
            {
                return View("Masterfile");
            }
            string[] Fields;
            int count = 0;
            string Headers = String.Empty;
            DataSet dataSet = new DataSet();
            try
            {
                string path = Path.Combine(Server.MapPath(Helper.RootFolder), fileName);

                string extension = Path.GetExtension(fileName).ToLower();

                switch (extension)
                {
                    case ".txt":
                    case ".csv":

                        string[] Lines = System.IO.File.ReadAllLines(path);

                        Headers = Lines.FirstOrDefault().ToString();

                        Headers = Headers.Replace("\"", "");

                        Lines = Lines.Skip(1).ToArray();

                        if (!(Headers.Equals(accounts)) && !(Headers.Equals(articles)))
                        {
                            string x = $"{IWSLocalResource.GenericError}{Environment.NewLine}{IWSLocalResource.DataFormat}";

                            var s = new { Description = x };

                            return Json(s);
                        }

                        if (Headers.Equals(accounts))
                        {
                            option = IWSLocalResource.account;

                            List<Account> Account = new List<Account>();
                            foreach (var line in Lines)
                            {
                                Fields = line.Split(new char[] { ';' });

                                Account.Add(new Account
                                {
                                    id = Fields[0],
                                    name = Fields[1],
                                    description = Fields[3],
                                    dateofopen = DateTime.Now,
                                    dateofclose = DateTime.Now,
                                    balance = Convert.ToDecimal(Fields[2]),
                                    CompanyID = companyId,
                                    ParentId = string.Empty,
                                    IsUsed = true
                                });

                            }

                            foreach (var item in Account)
                            {
                                var u = db.Accounts.Where(o => o.id.Equals(item.id)
                                           && o.CompanyID.Equals(item.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Accounts.InsertOnSubmit(item);
                                    count += 1;
                                }
                            }

                        }
                        if (Headers.Equals(articles))
                        {
                            option = IWSLocalResource.articles;

                            List<Article> Article = new List<Article>();
                            foreach (var line in Lines)
                            {
                                Fields = line.Split(new char[] { ';' });

                                Article.Add(new Article
                                {
                                    id = Fields[0],
                                    name = Fields[1],
                                    description = Fields[2],
                                    price = Convert.ToDecimal(Fields[3]),
                                    CompanyID = companyId,
                                });

                            }

                            foreach (var item in Article)
                            {
                                var u = db.Articles.Where(o => o.id.Equals(item.id)
                                           && o.CompanyID.Equals(item.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Articles.InsertOnSubmit(item);
                                    count += 1;
                                }
                            }
                        }

                        break;
                    case ".xls":
                    case ".xlsx":

                        string connectionString = String.Empty;

                        DataTable dataTable = new DataTable();

                        if (extension == ".xls")
                        {
                            connectionString = providerXLS + path + extensionXLS;
                        }
                        else if (extension == ".xlsx")
                        {
                            connectionString = providerXLSX + path + extensionXLSX;

                        }

                        OleDbConnection oleDBConnection = new OleDbConnection(connectionString);

                        oleDBConnection.Open();
                        dataTable = oleDBConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        oleDBConnection.Close();

                        if (dataTable == null)
                        {
                            return null;
                        }

                        String[] excelSheets = new String[dataTable.Rows.Count];

                        foreach (DataRow row in dataTable.Rows)
                        {
                            excelSheets[count] = row["TABLE_NAME"].ToString();
                            count++;
                        }

                        string query = $"Select * from [{excelSheets[0]}]";

                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, oleDBConnection))
                        {
                            dataAdapter.Fill(dataSet);
                        }

                        string[] columnNames = dataSet.Tables[0].Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

                        string[] account = { "id", "name", "balance", "description" };

                        string[] customer = { "customerid", "name", "street", "city", "state", "zip", "phone", "email", "accountid", "IBAN" };

                        string[] supplier = { "supplierid", "name", "street", "city", "state", "zip", "phone", "email", "accountid", "IBAN" };

                        if (!account.SequenceEqual(columnNames) && !customer.SequenceEqual(columnNames) && !supplier.SequenceEqual(columnNames))
                        {
                            string x = $"{IWSLocalResource.GenericError}{Environment.NewLine}{IWSLocalResource.DataFormat}";

                            var s = new { Description = x };

                            return Json(s);
                        }

                        if (!(dataSet.Tables[0].Rows.Count > 0))
                        {
                            string x = $"{IWSLocalResource.GenericError}{Environment.NewLine}{IWSLocalResource.DataFormat} ";

                            var s = new { Description = x };

                            return Json(s);
                        }

                        if (account.SequenceEqual(columnNames))
                        {

                            List<Account> Accounts = new List<Account>();
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                Account Account = new Account
                                {
                                    id = dataSet.Tables[0].Rows[i][0].ToString(),
                                    name = dataSet.Tables[0].Rows[i][1].ToString(),
                                    description = dataSet.Tables[0].Rows[i][3].ToString(),
                                    dateofopen = DateTime.Now,
                                    dateofclose = DateTime.Now,
                                    balance = Convert.ToDecimal(dataSet.Tables[0].Rows[i][2].ToString()),
                                    CompanyID = companyId.ToString(),
                                    ParentId = string.Empty,
                                    IsUsed = true
                                };
                                Accounts.Add(Account);
                            }

                            count = 0;

                            foreach (var n in Accounts)
                            {
                                var u = db.Accounts.Where(o => o.id.Equals(n.id)
                                           && o.CompanyID.Equals(n.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Accounts.InsertOnSubmit(n);
                                    count += 1;
                                }
                            }

                        }

                        if (customer.SequenceEqual(columnNames))
                        {

                            List<Customer> Customers = new List<Customer>();
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                Customer Customer = new Customer
                                {
                                    id = dataSet.Tables[0].Rows[i][0].ToString(),
                                    name = dataSet.Tables[0].Rows[i][1].ToString(),
                                    street = dataSet.Tables[0].Rows[i][2].ToString(),
                                    city = dataSet.Tables[0].Rows[i][3].ToString(),
                                    state = dataSet.Tables[0].Rows[i][4].ToString(),
                                    zip = dataSet.Tables[0].Rows[i][5].ToString(),
                                    Phone = dataSet.Tables[0].Rows[i][6].ToString(),
                                    Email = dataSet.Tables[0].Rows[i][7].ToString(),
                                    accountid = dataSet.Tables[0].Rows[i][8].ToString(),
                                    CompanyID = companyId.ToString(),
                                    IBAN = dataSet.Tables[0].Rows[i][9].ToString()
                                };
                                Customers.Add(Customer);
                            }

                            count = 0;

                            foreach (var item in Customers)
                            {
                                var u = db.Customers.Where(o => o.id.Equals(item.id)
                                           && o.CompanyID.Equals(item.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Customers.InsertOnSubmit(item);
                                    count += 1;
                                }
                            }

                        }

                        if (supplier.SequenceEqual(columnNames))
                        {

                            List<Supplier> Suppliers = new List<Supplier>();
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                Supplier Supplier = new Supplier
                                {
                                    id = dataSet.Tables[0].Rows[i][0].ToString(),
                                    name = dataSet.Tables[0].Rows[i][1].ToString(),
                                    street = dataSet.Tables[0].Rows[i][2].ToString(),
                                    city = dataSet.Tables[0].Rows[i][3].ToString(),
                                    state = dataSet.Tables[0].Rows[i][4].ToString(),
                                    zip = dataSet.Tables[0].Rows[i][5].ToString(),
                                    Phone = dataSet.Tables[0].Rows[i][6].ToString(),
                                    Email = dataSet.Tables[0].Rows[i][7].ToString(),
                                    accountid = dataSet.Tables[0].Rows[i][8].ToString(),
                                    CompanyID = companyId.ToString(),
                                    IBAN = dataSet.Tables[0].Rows[i][9].ToString()
                                };
                                Suppliers.Add(Supplier);
                            }

                            count = 0;

                            foreach (var item in Suppliers)
                            {
                                var u = db.Suppliers.Where(o => o.id.Equals(item.id)
                                           && o.CompanyID.Equals(item.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Suppliers.InsertOnSubmit(item);
                                    count += 1;
                                }
                            }

                        }

                        break;
                }

                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);

                if (count > 0)
                {
                    msg = $"{count} {IWSLocalResource.Imported} {option} ";
                }
                else
                {
                    msg = $"{IWSLocalResource.ImportedNone}";
                }
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);

                msg = ex.Message;
            }
            //}
            var Message = new { Description = msg };

            return Json(Message);
        }

        #region Helper
        private class Helper
        {
            public const string RootFolder = "~/Content/Uploads";
            public static string Model { get { return RootFolder; } }

            public static string[] AllowedFileExtensions = new string[] { ".csv", ".txt", ".xls", ".xlsx" };
        }
        #endregion
    }
}