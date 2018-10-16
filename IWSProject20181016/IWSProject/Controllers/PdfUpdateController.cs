using DevExpress.Web.Mvc;
using IWSProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace IWSProject.Controllers
{
    public class PdfUpdateController : IWSBaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["IsVending"] == null)
            {
                Session["IsVending"] = "SU";
            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            int modelId = (int)IWSLookUp.ComptaMasterModelId.Default;
            if (Session["ModelId"] != null)
                modelId = (int)Session["ModelId"];

            return PartialView("_GridViewPartial", IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdatePdf(int documentId)
        {
            Session["documentId"] = documentId;
            return null;
        }

        public ActionResult UpdatePdfPartial(bool param)
        {
            int id = (int)Session["documentId"];
            if (param)
            {
                UpdatePdfDetails(id);
            }
            return PartialView("UpdatePdfPartial");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(int currentModelId)
        {
            Session["ModelId"] = currentModelId;
            Session["IsVending"] = IsVending(currentModelId);
            return PartialView("CallbackPanelPartialView",
                    IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)currentModelId));
        }
        private string IsVending(int modelId)
        {
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.VendorInvoice) ||
                (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment)))
            {
                return "SU";
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.CustomerInvoice) ||
                (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement)))
            {
                return "CU";
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.CustomerInvoice))
            {
                return "GL";
            }
            return null;
        }
        public ActionResult UploadFile(string documentId)
        {
            Session["documentId"] = documentId;
            return null;
        }

        public FileResult DownloadFile(int itemId)
        {
            List<UploadedFileInfo> files = GetFileDetail(itemId);

            var file = (from f in files
                        where f.Id.Equals(itemId)
                        select new { f.FileName, f.FileContent, f.ContentType }).ToList().FirstOrDefault();

            return File(file.FileContent, file.ContentType, file.FileName);
        }

        public ActionResult UploadControlCallbackAction()
        {
            UploadControlExtension.GetUploadedFiles("uploadControl", UploadControlSettings.UploadValidationSettings,
                                                                        UploadControlSettings.FileUploadComplete);
            return null;
        }

        #region Convert from/to object/byte

        private static byte[] ObjectToByteArray(object o)
        {
            BinaryFormatter binary = new BinaryFormatter();

            using (var stream = new MemoryStream())
            {
                binary.Serialize(stream, o);

                return stream.ToArray();
            }
        }

        private static object ByteArrayToObject(byte[] bytesArray)
        {
            using (var stream = new MemoryStream())
            {
                var binary = new BinaryFormatter();

                stream.Write(bytesArray, 0, bytesArray.Length);

                stream.Seek(0, SeekOrigin.Begin);

                var o = binary.Deserialize(stream);

                return o;
            }
        }

        #endregion

        #region delete next
        //private List<UploadedFileInfo> GetFileDetailx(int Id)
        //{
        //    List<UploadedFileInfo> filesDetail = new List<UploadedFileInfo>();

        //    UploadedFileInfo fileDetail = new UploadedFileInfo();

        //    string query = "Select id, FileName, FileContent, ContentType From MasterCompta Where Id= @Id";
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            try
        //            {


        //                SqlParameter p = new SqlParameter("@Id", Id);
        //                connection.Open();
        //                command.Parameters.Add(p);
        //                SqlDataReader reader = command.ExecuteReader();
        //                DataTable dataTable = new DataTable();
        //                dataTable.Load(reader);
        //                List<DataRow> dataRows = dataTable.Select().ToList();
        //                filesDetail = (from DataRow dr in dataTable.Rows
        //                           select new UploadedFileInfo()
        //                           {
        //                               Id = Convert.ToInt32(dr["Id"]),
        //                               FileName = dr["FileName"].ToString(),
        //                               FileContent = ObjectToByteArray(dr["FileContent"]),
        //                               ContentType = dr["ContentType"].ToString()
        //                           }).ToList();
        //            }
        //            catch (Exception ex)
        //            {
        //                IWSLookUp.LogException(ex);
        //            }
        //        }
        //    }
        //    return filesDetail;
        //}
        #endregion

        private static void UpdatePdfDetails(int Id)
        {
            string query = "Update MasterCompta Set FileName = NULL, FileContent = NULL, ContentType = NULL Where Id= @Id;";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                        command.ExecuteScalar();
                        command.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                    }
                    finally
                    {
                        if (connection.State.Equals(ConnectionState.Open))
                            connection.Close();
                    }
                }
            }
        }

        private static List<UploadedFileInfo> GetFileDetail(int Id)
        {
            List<UploadedFileInfo> files = new List<UploadedFileInfo>();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "Select id, FileName, FileContent, ContentType From MasterCompta Where Id= @Id";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand(query))
                {
                    try
                    {
                        SqlParameter p = new SqlParameter("@Id", Id);
                        command.Parameters.Add(p);
                        command.Connection = connection;
                        if (!connection.State.Equals(ConnectionState.Open))
                            connection.Open();
                        using (SqlDataReader sqlDatareader = command.ExecuteReader())
                        {
                            while (sqlDatareader.Read())
                            {
                                files.Add(new UploadedFileInfo
                                {
                                    Id = Convert.ToInt32(sqlDatareader["Id"]),
                                    FileName = sqlDatareader["FileName"].ToString(),
                                    FileContent = ObjectToByteArray(sqlDatareader["FileContent"]),
                                    ContentType = sqlDatareader["ContentType"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                    }
                    finally
                    {
                        if(connection.State.Equals(ConnectionState.Open))
                            connection.Close();

                    }
                }
            }
            return files;
        }

        private void RemoveFile(string path)
        {
            System.IO.File.Delete(path);
        }

        private void CommitUploadedFiles(string documentUrl)
        {
            UploadedFileInfo file = Session[UploadControlSettings.UploadedFileSessionKey] as UploadedFileInfo;
            if (file == null ||
                !Equals(UploadControlSettings.GetFileRelativePath(file), documentUrl))
            {
                return;
            }

            System.IO.File.WriteAllBytes(UploadControlSettings.GetFileFullPath(documentUrl), file.FileContent);
        }
    }

    public class UploadControlSettings
    {
        private const string UploadDirectory = "~/Documents/";

        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".png", ".jpg", ".jpeg", ".pdf" },
            MaxFileSize = 4000000
        };

        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {

                int itemId = Convert.ToInt32(HttpContext.Current.Session["documentId"]);
                string resultFilePath = HttpContext.Current.Request.MapPath(UploadDirectory + e.UploadedFile.FileName);
                IUrlResolutionService urlResolver = (IUrlResolutionService)sender;
                if (urlResolver != null)
                {
                    UploadedFileInfo fileInfo = new UploadedFileInfo()
                    {

                        Id = itemId,
                        FileName = e.UploadedFile.FileName,
                        FileContent = e.UploadedFile.FileBytes,
                        ContentType = e.UploadedFile.ContentType
                    };

                    SaveFileDetails(fileInfo);

                    e.CallbackData += fileInfo.FileName;
                }

            }
        }

        public static string UploadedFileSessionKey = "UploadedFile";
        public static string GetFileFullPath(string relativePath)
        {
            return HttpContext.Current.Server.MapPath(relativePath);
        }
        public static string GetFileRelativePath(UploadedFileInfo file)
        {
            return Path.Combine("~/Documents", file.FileName);
        }


        private static void SaveFileDetails(UploadedFileInfo fileDetails)
        {
            string query = "Update MasterCompta Set FileName = @FileName, FileContent = @FileContent, ContentType = @ContentType Where Id= @Id;";
            //string query = "update company set logo=@FileContent where id = '1000';";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.
                            ConnectionStrings["DefaultConnection"].ToString()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        //SqlParameter p = new SqlParameter("@FileContent", fileDetails.FileContent);
                        List<SqlParameter> p = new List<SqlParameter>
                        {
                            new SqlParameter("@Id", fileDetails.Id),
                            new SqlParameter("@FileName", fileDetails.FileName),
                            new SqlParameter("@FileContent", fileDetails.FileContent),
                            new SqlParameter("@ContentType", fileDetails.ContentType)
                        };

                        connection.Open();
                        AddParameters(command, p.ToArray());
                        //command.Parameters.Add("@FileContent", SqlDbType.VarBinary).Value = fileDetails.FileContent;
                        command.ExecuteScalar();
                        command.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                    }
                    finally
                    {
                        if (connection.State.Equals(ConnectionState.Open))
                            connection.Close();
                    }
                }
            }
        }

        private static void AddParameters(SqlCommand command, params SqlParameter[] p)
        {
            if (p != null && p.Any())
            {
                command.Parameters.AddRange(p);
            }
        }

    }

    public class UploadedFileInfo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public string ContentType { get; set; }
    }
}
