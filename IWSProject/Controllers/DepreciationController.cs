using IWSProject.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using IWSProject.Models.Entities;
using IWSProject.Content;
using System.Data.Linq;
using System.Linq;

namespace IWSProject.Controllers
{
    [Authorize]
    public class DepreciationController : IWSBaseController
    {
        // GET: Depreciation
        public ActionResult Index()
        {
            ViewBag.Period = IWSLookUp.GetDepreciationPeriods();

            ViewBag.Currency = IWSLookUp.GetCurrency();

            return View(IWSLookUp.GetDepreciation(null, IWSLookUp.DepreciationType.StraightLine));
        }
        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial(string currentPeriod, string currentType)
        {
            int type = Convert.ToInt32(currentType);
            return PartialView("MasterGridViewPartial",
                            IWSLookUp.GetDepreciation(currentPeriod, (IWSLookUp.DepreciationType)type));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs, string currentPeriod, string currentType)
        {

            #region data processing
            int type = 0;
            try
            {
                type = Convert.ToInt32(currentType);
                if (!string.IsNullOrWhiteSpace(selectedIDs))
                {
                    MakeGeneralLedger(selectedIDs, currentPeriod, type);
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            #endregion

            return PartialView("CallbackPanelPartialView",
                            IWSLookUp.GetDepreciation(currentPeriod, (IWSLookUp.DepreciationType)type));
        }
        public ActionResult CustomGridViewCallback(string currentPeriod, string currentType, bool isChecked)
        {
            Session["checked"] = isChecked;

            int type = Convert.ToInt32(currentType);

            return PartialView("MasterGridViewPartial",
                            IWSLookUp.GetDepreciation(currentPeriod, (IWSLookUp.DepreciationType)type));
        }

        #region helper
        private void MakeGeneralLedger(string IDs, string period, int type)
        {
            decimal amount = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            IList<string> items = new List<string>(IDs.Split(new string[] { ";" }, StringSplitOptions.None));
            foreach (string item in items)
            {
                var list = item.Split(new string[] { "," }, StringSplitOptions.None);
                amount += Convert.ToDecimal(list[2]);
                sb.Append(list[0]).Append(",");
            }
            string IDx = sb.Remove(sb.Length - 1, 1).ToString();
            string[] IDa = IDx.Split(new string[] { "," }, StringSplitOptions.None);
            List<ImmoDetailViewModel> details = IWSLookUp.GetImmoDetail(IDa, period);
            MasterCompta header = details.Select(i => new MasterCompta()
            {
                CostCenter = i.CostCenter,
                account = "9999",
                HeaderText = IWSLocalResource.Depreciation,
                TransDate = i.TransDate,
                ItemDate = i.ItemDate,
                EntryDate = i.EntryDate,
                CompanyId = i.CompanyId,
                ModelId = (int)IWSLookUp.ComptaMasterModelId.GeneralLedger,
                IsValidated=false
            }).FirstOrDefault();
            int id = MakeGLHeader(header);
            DetailCompta detailCompta = details.Select(i => new DetailCompta()
            {
                transid = id,
                account = i.Account,
                side = i.Side,
                oaccount = i.OAccount,
                amount = amount,
                duedate = i.DueDate,
                Currency = i.Currency,
                ModelId = (int)IWSLookUp.ComptaMasterModelId.GeneralLedger,
                Terms = null,
                text = null,
                Balanced = false
            }).FirstOrDefault();
            id = MakeGLDetail(detailCompta);
            if (id > 0)
                UpdateDepreciationDetail(IDa, period);
        }
        private int MakeGLHeader(MasterCompta masterCompta)
        {
            int id = 0;
            try
            {
                db.MasterComptas.InsertOnSubmit(masterCompta);
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                id = db.MasterComptas.Max(i => i.id);
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
            }
            return id;
        }
        private int MakeGLDetail(DetailCompta detailCompta)//List<DetailCompta> 
        {
            int id = 0;
            try
            {
                db.DetailComptas.InsertOnSubmit(detailCompta);
                //foreach (var item in detailCompta)
                //{
                //    if (item.amount != 0)
                //    {
                        //db.DetailComptas.InsertOnSubmit(item);
                        //id++;
                //    }
                //}
                db.SubmitChanges(ConflictMode.FailOnFirstConflict);
                id++;
                int transid = detailCompta.transid;
                bool rs = IWSLookUp.SetJournal(transid);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
            }
            return id;
        }
        private void UpdateDepreciationDetail(string[] IDs, string period)
        {
            var details =
                    from d in db.DepreciationDetails
                    where
                        IDs.Contains(d.TransId) &&
                        d.Period == period //&&
                        //d.CompanyId == companyId
                    select d;
                    foreach (var detail in details)
                    {
                        detail.IsValidated = true;
                    }
            db.SubmitChanges();

        }
        #endregion
    }
}