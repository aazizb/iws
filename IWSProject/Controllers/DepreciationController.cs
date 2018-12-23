using IWSProject.Content;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    public class DepreciationController : IWSBaseController
    {
        // GET: Depreciation
        public ActionResult Index()
        {
            ViewBag.Period = IWSLookUp.GetDepreciationPeriods();
            ViewBag.Currency = IWSLookUp.GetCurrency();
            return View();
        }
        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial(string currentPeriod)
        {
            string period = DateToYM(currentPeriod);
            return PartialView("MasterGridViewPartial", IWSLookUp.GetDepreciation(period));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewDelete(int id)
        {
            var model = db.DepreciationDetails;
            try
            {
                var item = model.FirstOrDefault(i => i.Id == id);
                if (item != null)
                    model.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                ViewData["GenericError"] = e.Message;
                IWSLookUp.LogException(e);
            }
            return PartialView("AssetsGridViewPartial", IWSLookUp.GetAssets());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs, string currentPeriod)
        {
            #region data processing
            string period = DateToYM(currentPeriod);
            try
            {
                if (!string.IsNullOrWhiteSpace(selectedIDs))
                {
                    MakeGeneralLedger(selectedIDs);
                }
                else if (!string.IsNullOrWhiteSpace(currentPeriod))
                {
                    DateTime dateTime = Convert.ToDateTime(currentPeriod);
                    List<AssetViewModel> assets = IWSLookUp.GetAssets(dateTime);
                    foreach (AssetViewModel asset in assets)
                    {
                        if (asset != null)
                        {
                            DeleteDepreciation(asset.Id);
                            SetDepreciation(asset);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetDepreciation(period));
            #endregion
        }
        public ActionResult CustomGridViewCallback(string currentPeriod, bool isChecked)
        {
            ViewBag.select = isChecked;
            string period = DateToYM(currentPeriod);
            return PartialView("MasterGridViewpartial", IWSLookUp.GetDepreciation(period));
        }
        public ActionResult DepreciationView()
        {
            ViewBag.Period = IWSLookUp.GetDepreciationPeriods();
            ViewBag.Currency = IWSLookUp.GetCurrency();
            return PartialView();
        }
        #region make GL
        private void MakeGeneralLedger(string IDs)
        {
            decimal amount = 0;
            int newId = 0;
            string period = string.Empty;
            string IDx = string.Empty;
            IList<string> items = new List<string>(IDs.Split(new string[] { ";" }, StringSplitOptions.None));
            foreach (string item in items)
            {
                var list = item.Split(new string[] { "," }, StringSplitOptions.None);
                IDx = list[0];
                period = DateToYM(list[1]);
                amount = Convert.ToDecimal(list[2]);
                ImmoDetailViewModel details = IWSLookUp.GetImmoDetail(IDx, period);
                MasterCompta header = new MasterCompta()
                {
                    CostCenter = details.CostCenter,
                    account = "9999",
                    HeaderText = IWSLocalResource.Depreciation,
                    TransDate = details.TransDate,
                    ItemDate = details.ItemDate,
                    EntryDate = details.EntryDate,
                    CompanyId = details.CompanyId,
                    ModelId = (int)IWSLookUp.ComptaMasterModelId.GeneralLedger,
                    IsValidated = false
                };
                newId = MakeGLHeader(header);
                DetailCompta detailCompta = new DetailCompta()
                {
                    transid = newId,
                    account = details.OAccount,
                    side = details.Side,
                    oaccount = details.Account,
                    amount = amount,
                    duedate = details.DueDate,
                    Currency = details.Currency,
                    ModelId = (int)IWSLookUp.ComptaMasterModelId.GeneralLedger,
                    Terms = null,
                    text = null,
                    Balanced = false
                };
                newId = MakeGLDetail(detailCompta);
                if (newId > 0)
                    UpdateDepreciationDetail(IDx, period);
            }
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
        private int MakeGLDetail(DetailCompta detailCompta)
        {
            int id = 0;
            try
            {
                db.DetailComptas.InsertOnSubmit(detailCompta);
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
        private void UpdateDepreciationDetail(string IDs, string period)
        {
            string companyId = (string)Session["CompanyId"];
            var details = from d in db.DepreciationDetails
                          where
                            IDs.Equals(d.TransId) &&
                            d.Period == period
                            select d;
            foreach (var detail in details)
            {
                detail.IsValidated = true;
            }
            db.SubmitChanges();
        }
        #endregion
        #region compute depreciation
        private void SetDepreciation(AssetViewModel asset)
        {
            int frequency = 30;
            List<DepreciationInfo> depreciationInfos = ComputeDepreciation((double)asset.BookValue, (double)asset.ScrapValue, asset.LifeSpan,
                                    frequency, asset.DepreciationType, (double)asset.Rate, asset.Id, asset.StartDate, asset.Currency);

            var depreciationDetails = db.DepreciationDetails;

            foreach (var item in depreciationInfos)
            {
                DepreciationDetail detail = new DepreciationDetail
                {
                    TransId = item.TransId,
                    Period = item.Period,
                    Depreciation = (decimal)item.Depreciation,
                    Accumulated = (decimal)item.Accumulation,
                    BookValue = (decimal)item.BookValue,
                    Percentage = (decimal)item.Percentage,
                    Currency = item.Currency,
                    IsValidated = false
                };
                depreciationDetails.InsertOnSubmit(detail);
            }
            db.SubmitChanges();
        }

        private List<DepreciationInfo> ComputeDepreciation(double costValue, double scrapValue, int lifeSpan, int frequency,
                                      int DepreciationType, double rate, string transId, DateTime startDate, string currency)
        {
            List<DepreciationInfo> depreciation = new List<DepreciationInfo>();

            if (costValue <= 0 || scrapValue < 0 || lifeSpan <= 0 || costValue <= scrapValue)
                return depreciation;
            DepreciationInfo dpInfo = new DepreciationInfo();
            double bookValue = costValue;
            if (DepreciationType.Equals((int)IWSLookUp.DepreciationType.StraightLine))
            {
                bookValue -= scrapValue;
            }
                double depreciationValue = Math.Round(bookValue / lifeSpan,2);
            if (DepreciationType.Equals((int)IWSLookUp.DepreciationType.Degressive))
            {
                if(lifeSpan > 1)
                    depreciationValue = Math.Round(rate * depreciationValue,2);
            }
            if (depreciationValue >= bookValue)
            {
                bookValue = scrapValue;
            }
            else
            {
                bookValue -= depreciationValue;
            }
            DateTime dateTimePeriod = startDate;
            string stringMonth = dateTimePeriod.Month < 10 ?
                    "0" + dateTimePeriod.Month.ToString() :
                                dateTimePeriod.Month.ToString();
            string  stringPeriod = dateTimePeriod.Year + "-" + stringMonth;
            dpInfo = new DepreciationInfo
            {
                TransId = transId,
                Period = stringPeriod,
                StraightLineDepreciation = 0,
                StraightLineBookValue = 0,
                Depreciation = depreciationValue,
                Accumulation = 0,
                BookValue = bookValue,
                Percentage = 0,
                Currency = currency
            };
            depreciation.Add(dpInfo);
            return depreciation;
        }



        private string DateToYM(string stringDate)
        {
            if (stringDate == null)
                return null;
            DateTime dateTime = Convert.ToDateTime(stringDate);
            var m = (dateTime.Month <= 9) ? "0" + (dateTime.Month).ToString() : (dateTime.Month).ToString();
            var y = (dateTime.Year).ToString();
            return y + "-" + m;
        }
        private void DeleteDepreciation(string itemId)
        {
            var details = db.DepreciationDetails.Where(i => i.TransId == itemId && 
                                    i.IsValidated.Equals(false)).Select(i => new { i.Id });
            foreach (var detail in details)
            {
                MasterGridViewDelete(detail.Id);
            }
        }
        #endregion
    }
    public class DepreciationInfo
    {
        public string TransId { get; set; }
        public string Period { get; set; }
        public double StraightLineDepreciation { get; set; }
        public double StraightLineBookValue { get; set; }
        public double Depreciation { get; set; }
        public double BookValue { get; set; }
        public double Accumulation { get; set; }
        public double Percentage { get; set; }
        public string Currency { get; set; }

    }
}