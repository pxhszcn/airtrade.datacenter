using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using AirTrade.DataCenter.Models;

namespace AirTrade.DataCenter.Controllers
{
    public class StockTodayAllController : Controller
    {
        private StockDataDbContext db = new StockDataDbContext();

        // GET: StockTodayAll
        public ActionResult Index()
        {
            var totalRise = from stock in db.stock_today_all
                          where stock.changepercent > 0
                          select stock;
            var totalFall = from stock in db.stock_today_all
                          where stock.changepercent < 0
                          select stock;
            ViewBag.TotalRiseCount = totalRise.Count();
            ViewBag.TotalFallCount = totalFall.Count();

            return View(db.stock_today_all.ToList());
        }

        // GET: StockTodayAll/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTodayAll stockTodayAll = db.stock_today_all.Find(id);
            if (stockTodayAll == null)
            {
                return HttpNotFound();
            }
            return View(stockTodayAll);
        }

        // GET: StockTodayAll/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockTodayAll/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code,name,changepercent,trade,open,high,low,settlement,volume,turnoverratio,amount,per,pb,mktcap,nmc")] StockTodayAll stockTodayAll)
        {
            if (ModelState.IsValid)
            {
                db.stock_today_all.Add(stockTodayAll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockTodayAll);
        }

        // GET: StockTodayAll/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTodayAll stockTodayAll = db.stock_today_all.Find(id);
            if (stockTodayAll == null)
            {
                return HttpNotFound();
            }
            return View(stockTodayAll);
        }

        // POST: StockTodayAll/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code,name,changepercent,trade,open,high,low,settlement,volume,turnoverratio,amount,per,pb,mktcap,nmc")] StockTodayAll stockTodayAll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockTodayAll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockTodayAll);
        }

        // GET: StockTodayAll/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTodayAll stockTodayAll = db.stock_today_all.Find(id);
            if (stockTodayAll == null)
            {
                return HttpNotFound();
            }
            return View(stockTodayAll);
        }

        // POST: StockTodayAll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StockTodayAll stockTodayAll = db.stock_today_all.Find(id);
            db.stock_today_all.Remove(stockTodayAll);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
