using IWSProject.Content;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Threading;
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
        public ActionResult MasterGridViewPartial(string currentPeriod, string assetIDs)
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetDepreciation(currentPeriod, assetIDs));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DepreciationDetailsDelete(int id)
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
        public ActionResult CallbackPanelPartialView(string selectedIDs, string currentPeriod, string assetIDs)
        {
            #region data processing
            string period = DateToYMD(currentPeriod);
            try
            {
                if (!string.IsNullOrWhiteSpace(selectedIDs))
                {
                    MakeGeneralLedger(selectedIDs);
                }
                else if (!string.IsNullOrWhiteSpace(currentPeriod))
                {
                    ProcessDepreciation(period, assetIDs);
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetDepreciation(currentPeriod, assetIDs));
            #endregion
        }
        [ValidateInput(false)]
        public ActionResult GridLookupPartial()
        {
            if (ViewData["assets"] == null)
                ViewData["assets"] = IWSLookUp.GetAsset();
            return PartialView("GridLookupPartial", ViewData["assets"]);
        }
        private void ProcessDepreciation(string currentPeriod, string assetId)
        {
            DateTime dateTime = Convert.ToDateTime(currentPeriod);
            List<AssetViewModel> assets = IWSLookUp.GetAssets(dateTime, assetId);
            foreach (AssetViewModel asset in assets)
            {
                if (asset != null)
                {
                    if (IsPreviousDepreciated(asset.Id, asset.StartDate, asset.AssetStartDate))
                    {
                        DeleteDepreciation(asset.Id, asset.StartDate);
                        if(!IsPreviousDepreciated(asset.Id,asset.StartDate))
                                    SetDepreciation(asset);
                    }
                    else
                    {
                        string p = DateToYM(asset.StartDate.AddMonths(-1));
                        ViewData["GenericError"] = IWSLocalResource.DepreciationValidate1 + p + IWSLocalResource.DepreciationValidate2;
                        string previousPeriod = DateToYMD(asset.StartDate.AddMonths(-1));
                        ProcessDepreciation(previousPeriod, asset.Id);
                    }
                }
            }
        }

        public ActionResult CustomGridViewCallback(string currentPeriod, bool isChecked, string assetIDs)
        {
            ViewBag.select = isChecked;
           
            return PartialView("MasterGridViewpartial", IWSLookUp.GetDepreciation(currentPeriod, assetIDs));
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
                period = list[1];
                amount = Convert.ToDecimal(list[2], CultureInfo.InvariantCulture);
                ImmoDetailViewModel details = IWSLookUp.GetImmoDetail(IDx, period);
                MasterCompta header = new MasterCompta()
                {
                    CostCenter = details.CostCenter,
                    account = "6222",
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
                    amount = Math.Round(amount,2),
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
        private bool IsPreviousDepreciated(string assetId, DateTime period, DateTime assetStartdate)
        {
            string stringAssetStartDate = DateToYM(assetStartdate);
            string stringPeriod = DateToYM(period.AddMonths(-1));
            if (stringPeriod == stringAssetStartDate)
                return true;
            string companyId = (string)Session["CompanyId"];
            return db.DepreciationDetails.Any(c => c.TransId == assetId && c.Period == stringPeriod && c.CompanyId== companyId && c.IsValidated==true);
        }
        private bool IsPreviousDepreciated(string assetId, DateTime period)
        {
            string stringPeriod = DateToYM(period);
            string companyId = (string)Session["CompanyId"];
            return db.DepreciationDetails.Any(c => c.TransId == assetId && c.Period == stringPeriod && c.CompanyId == companyId && c.IsValidated == true);
        }
        #endregion
        #region compute depreciation
        private void SetDepreciation(AssetViewModel asset)
        {
            List<DepreciationInfo> depreciationInfos = ComputeDepreciation((double)asset.BookValue, (double)asset.ScrapValue, asset.LifeSpan,
                                   asset.Frequency, asset.DepreciationType, (double)asset.Rate, asset.Id, asset.StartDate, asset.Currency);

            var depreciationDetails = db.DepreciationDetails;
            string companyId = (string)Session["CompanyID"];
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
                    IsValidated = false, 
                    CompanyId = companyId
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
            double bookValue = Math.Round(costValue,2);

            bookValue -= scrapValue; 

            double depreciationValue = Math.Round((bookValue*frequency) / lifeSpan , 2);

            if (DepreciationType.Equals((int)IWSLookUp.DepreciationType.Degressive))
            {
                if(lifeSpan > 1)
                    depreciationValue = Math.Round(rate * bookValue,2);
            }
            if (depreciationValue >= bookValue)
            {
                bookValue = Math.Round(scrapValue,2);
            }
            else
            {
                if (DepreciationType.Equals((int)IWSLookUp.DepreciationType.StraightLine))
                {
                    bookValue -= Math.Round(depreciationValue / frequency,2);
                }
                if (DepreciationType.Equals((int)IWSLookUp.DepreciationType.Degressive))
                {
                    bookValue -= Math.Round(depreciationValue/frequency,2);
                }

            }
            DateTime dateTimePeriod = startDate;
            string stringMonth = dateTimePeriod.Month < 10 ?
                    "0" + dateTimePeriod.Month.ToString() :
                                dateTimePeriod.Month.ToString();
            string  stringPeriod = dateTimePeriod.Year.ToString() + stringMonth;    //"-" +
            dpInfo = new DepreciationInfo
            {
                TransId = transId,
                Period = stringPeriod,
                StraightLineDepreciation = 0,
                StraightLineBookValue = 0,
                Depreciation = Math.Round(depreciationValue/frequency,2),
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
            return y + m;
        }
        private string DateToYM(DateTime dateTime)
        {
            var m = (dateTime.Month <= 9) ? "0" + (dateTime.Month).ToString() : (dateTime.Month).ToString();
            var y = (dateTime.Year).ToString();
            return y +  m;
        }
        private string DateToYMD(string period)
        {
            if (period.Length != 6)
                return null;
            var y = period.Substring(0, 4);
            int m =Convert.ToInt32(period.Substring(4, 2));
            string d = DateTime.DaysInMonth(Convert.ToInt32(y), m ).ToString();
            string mo = m < 10 ? "0" + m.ToString() : m.ToString();
            return y + '-' + mo + '-' + d;
        }
        private string DateToYMD(DateTime period)
        {
            string y = period.Year.ToString();
            int m = period.Month;
            string d = DateTime.DaysInMonth(Convert.ToInt32(y), m).ToString();
            string mo = m < 10 ? "0" + m.ToString() : m.ToString();
            return y + '-' + mo + '-' + d;
        }
        private void DeleteDepreciation(string assetId, DateTime period)
        {
            string stringPeriod = DateToYM(period);
            string companyId = (string)Session["CompanyId"];
            var details = db.DepreciationDetails.Where(i => i.TransId == assetId && i.Period == stringPeriod &&
                          i.CompanyId==companyId && i.IsValidated==false).Select(i => new { i.Id });
            foreach (var detail in details)
            {
                DepreciationDetailsDelete(detail.Id);
            }
            db.SubmitChanges();
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