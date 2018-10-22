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
            return PartialView("ImmoGridViewPartial", IWSLookUp.GetDepreciation());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ImmoGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]Depreciation item)
        {
            var model = db.Depreciations;
            item.CompanyId = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Immo;
            item.Posted = DateTime.Now.Date;
            item.Updated = DateTime.Now.Date;
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

        private void SetDepreciation(Depreciation item)
        {
            int id = 0;
            if (item.Id == 0)//new depreciation
                id = db.Depreciations.Max(i => i.Id);
            id = item.Id;   //update existing one

            List<DepreciationInfo> depreciationInfos =
            ComputeDepreciation((double)item.CostOfAsset, (double)item.ScrapValue, (int)item.LifeSpan, id);

            var depreciationDetails = db.DepreciationDetails;
            foreach (var depreciationInfo in depreciationInfos)
            {
                DepreciationDetail detail = new DepreciationDetail
                {
                    TransId = depreciationInfo.TransId,
                    Period = depreciationInfo.Period,
                    StraightLineDepreciation = (decimal)depreciationInfo.StraightLineDepreciation,
                    StraightLineBookValue = (decimal)depreciationInfo.StraightLineBookValue,
                    Depreciation = (decimal)depreciationInfo.Depreciation,
                    Accumulated = (decimal)depreciationInfo.Accumulation,
                    BookValue = (decimal)depreciationInfo.BookValue,
                    Percentage = (decimal)depreciationInfo.Percentage
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
        public ActionResult ImmoGridViewPartialDelete(int id)
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
        public ActionResult ImmoDetailGridView(int transId)
        {
            return PartialView("ImmoDetailGridViewPartial", IWSLookUp.GetDepreciationDetail(transId));
        }

        private List<DepreciationInfo> ComputeDepreciation(double costValue, double scrapValue, int period, int transId)
        {
            List<DepreciationInfo> depreciation = new List<DepreciationInfo>();

            if (costValue <= 0 || scrapValue <= 0 || period <= 0)
                return depreciation;

            double accumulation = 0;

            double bookValue = costValue - scrapValue;

            double yearlyDepreciation = bookValue / period;

            double straightLineBookValue = costValue;  

            double expense = 0;

            int sum = period * (period + 1) / 2;

            int totalPeriod = period;

            for (int px = 0; px < period; px++)
            {
                double percentage = totalPeriod / (double)sum;

                straightLineBookValue -= yearlyDepreciation;

                expense = bookValue * percentage;

                costValue -= expense;

                accumulation += expense;

                DepreciationInfo dpInfo = new DepreciationInfo
                {
                    TransId = transId,

                    Period = px + 1,

                    StraightLineDepreciation = yearlyDepreciation,

                    StraightLineBookValue = straightLineBookValue,

                    Depreciation = expense,

                    Accumulation = accumulation,

                    BookValue = costValue,

                    Percentage = percentage * 100
                };

                depreciation.Add(dpInfo);

                totalPeriod--;
            }
            return depreciation;
        }
    }
    public class DepreciationInfo
    {
        public int TransId
        { get; set; }
        public int Period
        { get; set; }
        public double StraightLineDepreciation
        { get; set; }
        public double StraightLineBookValue
        { get; set; }
        public double Depreciation
        { get; set; }
        public double Accumulation
        { get; set; }
        public double BookValue
        { get; set; }
        public double Percentage
        { get; set; }
    }
}
