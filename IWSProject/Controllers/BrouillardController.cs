using DevExpress.Web.Mvc;
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
    public class BrouillardController : Controller
    {
        IWSDataContext db;
        public BrouillardController()
        {
            db = new IWSDataContext();
        }
        private object RootFolder = "~/Content/Uploads";
        public ActionResult Brouillard()
        {
            ViewData["Brouillard"] = IWSLookUp.GetBrouillardType();
            return View("Brouillard", RootFolder);
        }
        // GET: Brouillard
        public ActionResult Index()
        {
            return View(IWSLookUp.GetBrouillard());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetBrouillard());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs)
        {
            try
            {
                string companyId = (string)Session["CompanyID"];

                if (!string.IsNullOrEmpty(selectedIDs))
                {
                    IList<string> items = new List<string>(selectedIDs.Split(new string[] { ";" }, StringSplitOptions.None));
                    foreach (string item in items)
                    {
                        int ItemID;
                        string TypeDoc;
                        string NumPiece;
                        string oid;
                        int transId = 0;
                        var list = item.Split(new string[] { "," }, StringSplitOptions.None);

                        ItemID = Convert.ToInt32(list[0]);

                        NumPiece = list[1];

                        TypeDoc = list[2];
                        BrouillardHeaderViewModel header = new BrouillardHeaderViewModel();
                        BrouillardLineViewModel line = new BrouillardLineViewModel();
                        List<BrouillardViewModel> Brouillard = IWSLookUp.GetBrouillard(TypeDoc, NumPiece, companyId, ItemID);
                        if (TypeDoc == "VP" || TypeDoc == "VT" )
                        {
                            foreach (BrouillardViewModel b in Brouillard)
                            {
                                string owner = b.Account;
                                if (string.IsNullOrWhiteSpace(owner) || string.IsNullOrEmpty(owner))
                                    owner = "G";
                                owner = owner.Substring(0, 1).ToUpper();
                                if (owner == "C" && !b.IsValidated)
                                {
                                oid = Convert.ToString(b.OID);
                                CustomerInvoice invoiceHeader = new CustomerInvoice
                                {
                                    oid = b.OID,
                                    CostCenter = "20",
                                    account = b.Account,
                                    HeaderText = b.HeaderText,
                                    TransDate = b.TransDate,
                                    ItemDate = b.ItemDate,
                                    EntryDate = b.EntryDate,
                                    CompanyId = b.CompanyId,
                                    IsValidated = b.IsValidated
                                };
                                db.CustomerInvoices.InsertOnSubmit(invoiceHeader);
                                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                if (transId == 0)
                                    transId = db.CustomerInvoices.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                LineCustomerInvoice invoiceLine = new LineCustomerInvoice
                                {
                                    transid = transId,
                                    account = b.AccountID,
                                    side = b.Side,
                                    oaccount = b.OAccountID,
                                    amount = b.Amount,
                                    duedate = b.DueDate,
                                    text = b.HeaderText,
                                    Currency = b.Currency
                                };
                                db.LineCustomerInvoices.InsertOnSubmit(invoiceLine);
                                db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                                    ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                                if (owner == "F" && !b.IsValidated)
                                {
                                    oid = Convert.ToString(b.OID);
                                    VendorInvoice invoiceHeader = new VendorInvoice
                                    {
                                        oid = b.OID,
                                        CostCenter = "20",
                                        account = b.Account,
                                        HeaderText = b.HeaderText,
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.VendorInvoices.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    if (transId == 0)
                                        transId = db.VendorInvoices.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LineVendorInvoice invoiceLine = new LineVendorInvoice
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LineVendorInvoices.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                                #region generalledger


                                //if (owner == "G" && !b.IsValidated)
                                //{
                                //    oid = Convert.ToString(b.OID);
                                //    GeneralLedger invoiceHeader = new GeneralLedger
                                //    {
                                //        oid = b.OID,
                                //        CostCenter = "20",
                                //        HeaderText = b.HeaderText,
                                //        TransDate = b.TransDate,
                                //        ItemDate = b.ItemDate,
                                //        EntryDate = b.EntryDate,
                                //        CompanyId = b.CompanyId,
                                //        IsValidated = b.IsValidated
                                //    };
                                //    db.GeneralLedgers.InsertOnSubmit(invoiceHeader);
                                //    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                //    if (transId == 0)
                                //        transId = db.GeneralLedgers.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                //    LineGeneralLedger invoiceLine = new LineGeneralLedger
                                //    {
                                //        transid = transId,
                                //        account = b.AccountID,
                                //        side = b.Side,
                                //        oaccount = b.OAccountID,
                                //        amount = b.Amount,
                                //        duedate = b.DueDate,
                                //        text = b.HeaderText,
                                //        Currency = b.Currency
                                //    };
                                //    db.LineGeneralLedgers.InsertOnSubmit(invoiceLine);
                                //    db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                //                        ToList().ForEach(x => x.IsValidated = true);
                                //    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                //}
                                #endregion
                            }
                        }
                        if (TypeDoc == "AC" || TypeDoc == "AI")
                        {
                            foreach (BrouillardViewModel b in Brouillard)
                            {
                                string owner = b.Account;
                                if (string.IsNullOrWhiteSpace(owner) || string.IsNullOrEmpty(owner))
                                    owner = "G";
                                owner = owner.Substring(0, 1).ToUpper();
                                if (owner == "F" && !b.IsValidated)
                                {
                                    oid = Convert.ToString(b.OID);
                                    VendorInvoice invoiceHeader = new VendorInvoice
                                    {
                                        oid = b.OID,
                                        CostCenter = "10",
                                        account = b.Account,
                                        HeaderText = b.HeaderText,
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.VendorInvoices.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    //if (transId == 0)
                                    transId = db.VendorInvoices.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LineVendorInvoice invoiceLine = new LineVendorInvoice
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LineVendorInvoices.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                        db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                                if (owner == "C" && !b.IsValidated)
                                {
                                    oid = Convert.ToString(b.OID);
                                    CustomerInvoice invoiceHeader = new CustomerInvoice
                                    {
                                        oid = b.OID,
                                        CostCenter = "10",
                                        account = b.Account,
                                        HeaderText = b.HeaderText,
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.CustomerInvoices.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    if (transId == 0)
                                        transId = db.CustomerInvoices.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LineCustomerInvoice invoiceLine = new LineCustomerInvoice
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LineCustomerInvoices.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                                #region generalledger

                                if (owner == "G" && !b.IsValidated)
                                {
                                    oid = Convert.ToString(b.OID);
                                    GeneralLedger invoiceHeader = new GeneralLedger
                                    {
                                        oid = b.OID,
                                        CostCenter = "10",
                                        HeaderText = b.HeaderText,
                                        Area = "Achat",
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.GeneralLedgers.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    //if (transId == 0)
                                    transId = db.GeneralLedgers.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LineGeneralLedger invoiceLine = new LineGeneralLedger
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LineGeneralLedgers.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }

                                #endregion

                            }
                        }
                        if (TypeDoc == "BQ" || TypeDoc == "BK" || TypeDoc == "IM")
                        {
                            foreach (BrouillardViewModel b in Brouillard)
                            {
                                string owner = b.Account;
                                if (string.IsNullOrWhiteSpace(owner) || string.IsNullOrEmpty(owner))
                                    owner = "G";
                                owner = owner.Substring(0,1).ToUpper();
                                if (owner == "F" && !b.IsValidated)
                                {

                                    oid = Convert.ToString(b.OID);
                                    Payment invoiceHeader = new Payment
                                    {
                                        oid = b.OID,
                                        CostCenter = "15",
                                        account = b.Account,
                                        HeaderText = b.HeaderText,
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.Payments.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    //if (transId == 0)
                                    transId = db.Payments.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LinePayment invoiceLine = new LinePayment
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LinePayments.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                                if (owner == "C" && !b.IsValidated)
                                {
                                    oid = Convert.ToString(b.OID);
                                    Settlement invoiceHeader = new Settlement
                                    {
                                        oid = b.OID,
                                        CostCenter = "15",
                                        account = b.Account,
                                        HeaderText = b.HeaderText,
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.Settlements.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    //if (transId == 0)
                                    transId = db.Settlements.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LineSettlement invoiceLine = new LineSettlement
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LineSettlements.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                                if (owner == "G" && !b.IsValidated)
                                {
                                    oid = Convert.ToString(b.OID);
                                    GeneralLedger invoiceHeader = new GeneralLedger
                                    {
                                        oid = b.OID,
                                        CostCenter = "15",
                                        HeaderText = b.HeaderText,
                                        Area="Bank",
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.GeneralLedgers.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    //if (transId == 0)
                                    transId = db.GeneralLedgers.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LineGeneralLedger invoiceLine = new LineGeneralLedger
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LineGeneralLedgers.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                            }
                        }
                        if (TypeDoc == "CS" )
                        {
                            foreach (BrouillardViewModel b in Brouillard)
                            {
                                string owner = b.Account;
                                if (string.IsNullOrWhiteSpace(owner) || string.IsNullOrEmpty(owner))
                                    owner = "G";
                                owner = owner.Substring(0, 1).ToUpper();
                                if (owner == "F" && !b.IsValidated)
                                {

                                    oid = Convert.ToString(b.OID);
                                    Payment invoiceHeader = new Payment
                                    {
                                        oid = b.OID,
                                        CostCenter = "15",
                                        account = b.Account,
                                        HeaderText = b.HeaderText,
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.Payments.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    //if (transId == 0)
                                    transId = db.Payments.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LinePayment invoiceLine = new LinePayment
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LinePayments.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => ItemID.Equals(c.Id) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                                if (owner == "C" && !b.IsValidated)
                                {
                                    oid = Convert.ToString(b.OID);
                                    Settlement invoiceHeader = new Settlement
                                    {
                                        oid = b.OID,
                                        CostCenter = "15",
                                        account = b.Account,
                                        HeaderText = b.HeaderText,
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.Settlements.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    //if (transId == 0)
                                    transId = db.Settlements.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LineSettlement invoiceLine = new LineSettlement
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LineSettlements.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => ItemID.Equals(c.Id) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                                if (owner == "G" && !b.IsValidated)
                                {
                                    oid = Convert.ToString(b.OID);
                                    GeneralLedger invoiceHeader = new GeneralLedger
                                    {
                                        oid = b.OID,
                                        CostCenter = "15",
                                        HeaderText = b.HeaderText,
                                        Area = "Caisse",
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.GeneralLedgers.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    //if (transId == 0)
                                    transId = db.GeneralLedgers.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LineGeneralLedger invoiceLine = new LineGeneralLedger
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LineGeneralLedgers.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => ItemID.Equals(c.Id) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                            }
                        }
                        if (TypeDoc == "OB")
                        {
                            foreach (BrouillardViewModel b in Brouillard)
                            {
                                string owner = b.Account;
                                if (string.IsNullOrWhiteSpace(owner) || string.IsNullOrEmpty(owner))
                                    owner = "G";
                                owner = owner.Substring(0, 1).ToUpper();
                                if (owner == "G" && !b.IsValidated)
                                {
                                    oid = Convert.ToString(b.OID);
                                    GeneralLedger invoiceHeader = new GeneralLedger
                                    {
                                        oid = b.OID,
                                        CostCenter = "15",
                                        HeaderText = b.HeaderText,
                                        Area = "Bilan",
                                        TransDate = b.TransDate,
                                        ItemDate = b.ItemDate,
                                        EntryDate = b.EntryDate,
                                        CompanyId = b.CompanyId,
                                        IsValidated = b.IsValidated
                                    };
                                    db.GeneralLedgers.InsertOnSubmit(invoiceHeader);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                    //if (transId == 0)
                                    transId = db.GeneralLedgers.Where(c => c.CompanyId == companyId).Max(c => c.id);
                                    LineGeneralLedger invoiceLine = new LineGeneralLedger
                                    {
                                        transid = transId,
                                        account = b.AccountID,
                                        side = b.Side,
                                        oaccount = b.OAccountID,
                                        amount = b.Amount,
                                        duedate = b.DueDate,
                                        text = b.HeaderText,
                                        Currency = b.Currency
                                    };
                                    db.LineGeneralLedgers.InsertOnSubmit(invoiceLine);
                                    db.Brouillards.Where(c => NumPiece.Equals(c.NumPiece) && TypeDoc.Equals(c.TypeDoc)).
                                                        ToList().ForEach(x => x.IsValidated = true);
                                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            var model = IWSLookUp.GetBrouillard();
            return PartialView("CallbackPanelPartialView", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Brouillard item)
        {
            var model = db.Brouillards;

            item.CompanyId = (string)Session["CompanyID"];
            ViewData["item"] = item;
            ViewBag.IsNewRow = true;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    ViewData["NewKeyValue"] = item.Id;
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetBrouillard());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Brouillard item)
        {
            var model = db.Brouillards;
            ViewData["item"] = item;
            ViewBag.IsNewRow = false;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();

                    }
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetBrouillard());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.Brouillards;

            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetBrouillard());
        }

        [ValidateInput(false)]
        public ActionResult BrouillardPartial(string currentFileName)
        {
            return PartialView(RootFolder);
        }

        #region Helper
        private class Helper
        {
            public const string RootFolder = "~/Content/Uploads";
            public static string Model { get { return RootFolder; } }

            public static string[] AllowedFileExtensions = new string[] { ".xls", ".xlsx" };
        }

        private string SetDocType(string selectedItems, string docType)
        {

            string[] items = selectedItems.Split(new string[] { ";" },
                                        StringSplitOptions.RemoveEmptyEntries);

            items = items.Select(x => x + "," + docType).ToArray();

            return String.Join(";", items);
        }

        private DateTime? StringToDate(string stringDate)
        {
            if (stringDate.Length != 6)
                return null;
            string y = "20" + stringDate.Substring(4, 2);
            string m = stringDate.Substring(2, 2);
            string d = stringDate.Substring(0, 2);
            string s = $"{m}/{d}/{y}";
            if(DateTime.TryParse(s, out DateTime p))
            {
                return p;
            }
            return null;
        }

        private Decimal? StringToDecimal(string amount)
        {
            if (string.IsNullOrEmpty(amount))
                return null;
            int index = amount.LastIndexOf('.');
            if (index > 0)
                amount = amount.Substring(0, index);
            if(Decimal.TryParse(amount, out decimal a))
            {
                return a;
            }
            return null;
        }

        #endregion

        [HttpPost, ValidateInput(false)]
        public ActionResult UploadBrouillardToDb(string[] files, string brouillard)
        {
            const string providerXLS = "Provider=Microsoft.ACE.OLEDB.12.0.;Data Source=";
            const string extensionXLS = ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=20\"";
            const string providerXLSX = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            const string extensionXLSX = ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=20\"";
            string companyId = (string)Session["CompanyID"];
            string typeDoc = brouillard;
            //foreach (var item in files)
            //{
            string fullPath = files[0].ToString();
            string msg = string.Empty;
            string option = string.Empty;
            string fileName = fullPath.Substring(fullPath.IndexOf(@"\") + 1);

            if (fileName.Equals(null))
            {
                return View("Brouillard");
            }

            string sheetName = String.Empty;

            string periode = String.Empty;

            string accountId = String.Empty;

            int count = 0;
            try
            {
                string path = Path.Combine(Server.MapPath(Helper.RootFolder), fileName);

                string extension = Path.GetExtension(fileName).ToLower();

                if (extension == ".xls" || extension == ".xlsx")
                {
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
                        return null;

                    String[] excelSheets = new String[dataTable.Rows.Count];

                    List<Brouillard> Brouillards = new List<Models.Brouillard>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        excelSheets[count] = row["TABLE_NAME"].ToString();

                        sheetName = excelSheets[count].Replace("\'", "");

                        string query = $"Select * from [{excelSheets[count]}]";

                        DataSet dataSet = new DataSet();

                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, oleDBConnection))
                        {
                            dataAdapter.Fill(dataSet);
                        }

                        if (!(dataSet.Tables[0].Rows.Count > 0))
                        {
                            string x = $"{IWSLocalResource.GenericError}{Environment.NewLine}{IWSLocalResource.DataFormat} ";

                            var s = new { Description = x };

                            return Json(s);
                        }

                        string currency = dataSet.Tables[0].AsEnumerable().Skip(2).Take(1).
                                                    FirstOrDefault().Field<string>(14);
                        currency = currency.Substring(currency.LastIndexOf(":")+1).ToString();
                        string oaccount = dataSet.Tables[0].AsEnumerable().Skip(2).Take(1).
                                                    FirstOrDefault().Field<string>(7);

                        Brouillards = dataSet.Tables[0].AsEnumerable().Skip(9).Where(x=>x.Field<string>(0)!=null).
                            Select(b => new Brouillard
                            {
                                Date = b.Field<string>(0),
                                NumPiece = b.Field<string>(1),
                                AccountID = b.Field<string>(4),
                                OAccountID=oaccount,
                                Owner = b.Field<string>(6),
                                Text = b.Field<string>(9),
                                Debit = b.Field<string>(14),
                                Credit = b.Field<string>(17),
                                Currency=currency,
                                TypeDoc = typeDoc,
                                CompanyId = companyId,
                                IsValidated = false
                            }).ToList();
                        
                        count += 1;
                    }
                    db.Brouillards.InsertAllOnSubmit(Brouillards);

                    db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                }
                if (count > 0)
                {
                    msg = $"{IWSLocalResource.ImportedSage} ";
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

    }
}