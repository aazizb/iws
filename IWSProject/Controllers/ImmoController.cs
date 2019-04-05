using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    public class ImmoController : Controller
    {
        IWSDataContext db;
        public ImmoController()
        {
            db = new IWSDataContext();
        }
        // GET: Immobilisation
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult ImmoGridViewPartial()
        {
            ViewBag.ComboAccountId = IWSLookUp.GetAccounts();
            ViewBag.Currency = IWSLookUp.GetCurrency();
            return PartialView("ImmoGridViewPartial", IWSLookUp.GetDepreciation());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ImmoGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]Depreciation item)
        {
            var model = db.Depreciations;
            item.CompanyId = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Asset;
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            item.Posted = dateTime;// DateTime.Now.Date;
            item.Updated = dateTime;// DateTime.Now.Date;
            ViewData["immo"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();

                    SetDepreciation(item);
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            return PartialView("ImmoGridViewPartial", IWSLookUp.GetDepreciation());
        }

        private void SetDepreciation(Depreciation depreciation)
        {

            List<DepreciationInfo> depreciationInfos = ComputeDepreciation((double)depreciation.CostOfAsset, (double)depreciation.ScrapValue,
                                        (int)depreciation.LifeSpan, 30, depreciation.Id, (DateTime)depreciation.Started, depreciation.Currency);

            var depreciationDetails = db.DepreciationDetails;

            foreach (var item in depreciationInfos)
            {
                DepreciationDetail detail = new DepreciationDetail
                {
                    TransId = item.TransId,
                    Period = item.Period,
                    //StraightLineDepreciation = (decimal)item.StraightLineDepreciation,
                    //StraightLineBookValue = (decimal)item.StraightLineBookValue,
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

        [HttpPost, ValidateInput(false)]
        public ActionResult ImmoGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]Depreciation item)
        {
            var model = db.Depreciations;
            ViewData["immo"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(i => i.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        DeleteDepreciation(item);

                        SetDepreciation(item);
                    }
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            return PartialView("ImmoGridViewPartial", IWSLookUp.GetDepreciation());
        }

        private void DeleteDepreciation(Depreciation item)
        {
            var details = db.DepreciationDetails.Where(i => i.TransId == item.Id).Select(i => new { i.Id });
            foreach (var detail in details)
            {
                ImmoDetailDelete(detail.Id);
                db.SubmitChanges();
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ImmoGridViewPartialDelete(string id)
        {
            var model = db.Depreciations;
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
            return PartialView("ImmoGridViewPartial", IWSLookUp.GetDepreciation());
        }
        [ValidateInput(false)]
        public ActionResult ImmoDetailGridView(string transId)
        {
            ViewBag.TransId = transId;
            return PartialView("ImmoDetailGridViewPartial", IWSLookUp.GetDepreciationDetail(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ImmoDetailDelete(int transId)
        {
            var model = db.DepreciationDetails;
            try
            {
                var item = model.FirstOrDefault(i => i.Id == transId);
                if (item != null)
                    model.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                ViewData["GenericError"] = e.Message;
                IWSLookUp.LogException(e);
            }

            return null;
        }
        [ValidateInput(false)]
        private List<DepreciationInfo> ComputeDepreciation(double costValue, double scrapValue, int lifeSpan, int frequency,
                                                                        string transId, DateTime startDate, string currency)
        {
            List<DepreciationInfo> depreciation = new List<DepreciationInfo>();

            if (costValue <= 0 || scrapValue < 0 || lifeSpan <= 0 || costValue <= scrapValue)
                return depreciation;

            double accumulation = 0;

            double bookValue = costValue - scrapValue;

            double yearlyDepreciation = bookValue / lifeSpan;

            double straightLineBookValue = costValue;  

            double expense = 0;

            int sum = lifeSpan * (lifeSpan + 1) / 2;

            int totalPeriod = lifeSpan;
        
            DateTime dateTimePeriod = startDate;

            string stringPeriod;

            string stringMonth;

            for (int i = 0; i < lifeSpan; i++)
            {
                double percentage = totalPeriod / (double)sum;

                straightLineBookValue -= yearlyDepreciation;

                expense = bookValue * percentage;

                costValue -= expense;

                accumulation += expense;

                dateTimePeriod = dateTimePeriod.AddMonths(1);

                stringMonth = dateTimePeriod.Month < 10 ?  
                        "0"+ dateTimePeriod.Month.ToString() :
                                    dateTimePeriod.Month.ToString();

                stringPeriod = dateTimePeriod.Year + "-" + stringMonth;

                DepreciationInfo dpInfo = new DepreciationInfo
                {
                    TransId = transId,

                    Period = stringPeriod,

                    StraightLineDepreciation = yearlyDepreciation,

                    StraightLineBookValue = straightLineBookValue,

                    Depreciation = expense,

                    Accumulation = accumulation,

                    BookValue = costValue,

                    Percentage = percentage * 100,
                    Currency = currency
                };

                depreciation.Add(dpInfo);

                totalPeriod--;
            }
            return depreciation;
        }
    }

}
