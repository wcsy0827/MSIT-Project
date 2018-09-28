using F1005.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace F1005.Areas.ForeignExchange.Controllers
{
    public class TestHomeController : Controller
    {
        MyInvestEntities dc = new MyInvestEntities();
        // GET: TestHome
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDataTable()
        {
            var result = dc.FXtradeTable.ToList().Where(c => c.SummaryTable.UserName == "5566").Select(c=> new GetDataViewModel
            {
                Id = c.Id,
                SummaryId = c.SummaryId,
                TradeClass = c.TradeClass,
                CurrencyClass = c.CurrencyClass,
                NTD = c.NTD,
                USD = c.USD,
                ExchargeRate = c.ExchargeRate,
                Tradetime = c.SummaryTable.TradeDate.ToLongDateString(),
                UserName = c.SummaryTable.UserName
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void Post([FromBody]FXtradeTable tt)
        {
            dc.FXtradeTable.Add(tt);
            dc.SaveChanges();
        }

        public void Delete(int id)
        {
            FXtradeTable tt = dc.FXtradeTable.Find(id);

            if (tt == null)
                return;

            dc.FXtradeTable.Remove(tt);
            dc.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dc.Dispose();
            }
            base.Dispose(disposing);
        }
        //Jqgrid
        // GET: Admin/Ranger/QueryRanger
        public JsonResult Jqgridtable()
        {
            //取得所有資料
            //var List = dc.TradeTable.ToList();
            //var username = Session["User"].ToString();
            //var result = dc.FXtradeTable.ToList().Select(c => new GetDataViewModel
            //{
            //    Id = c.Id,
            //    SummaryId = c.SummaryId,
            //    TradeClass = c.TradeClass,
            //    CurrencyClass = c.CurrencyClass,
            //    NTD = c.NTD,
            //    USD = c.USD,
            //    ExchargeRate = c.ExchargeRate,
            //    Tradetime = c.SummaryTable.TradeDate.ToLongDateString(),
            //    UserName = c.SummaryTable.UserName
            //}).Where(c=>c.UserName=="msit119");
            var result = dc.FXtradeTable.ToList().Where(c => c.SummaryTable.UserName == "5566").Select(c => new GetDataViewModel
            {
                Id = c.Id,
                SummaryId = c.SummaryId,
                TradeClass = c.TradeClass,
                CurrencyClass = c.CurrencyClass,
                NTD = c.NTD,
                USD = c.USD,
                ExchargeRate = c.ExchargeRate,
                Tradetime = c.SummaryTable.TradeDate.ToLongDateString(),
                UserName = c.SummaryTable.UserName
            });

            //組成jqGrid要讀取的資料
            var jsonData = new
            {
                rows = result.ToList()    //jqGrid呈現在表格中的資料
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult chartpie()
        {
            var result = dc.FXtradeTable.GroupBy(x => x.CurrencyClass, x => x.NTD, (CurrencyClass, NTD) => new
            {
                Currency = CurrencyClass,
                NTD = NTD.Sum()
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}