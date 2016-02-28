using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirTrade.DataCenter.Models;

namespace AirTrade.DataCenter.Controllers
{
    public class StockBasicController : Controller
    {
        private StockDataDbContext db = new StockDataDbContext();

        // GET: StockBasic
        public ActionResult Index()
        {
            return View(db.stock_basic.ToList());
        }

        // GET: StockBasic/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockBasic stockBasic = db.stock_basic.Find(id);
            if (stockBasic == null)
            {
                return HttpNotFound();
            }
            return View(stockBasic);
        }

        // GET: StockBasic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockBasic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code,name,industry,area,pe,outstanding,totals,totalAssets,liquidAssets,fixedAssets,reserved,reservedPerShare,esp,bvps,pb,timeToMarket")] StockBasic stockBasic)
        {
            if (ModelState.IsValid)
            {
                db.stock_basic.Add(stockBasic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockBasic);
        }

        // GET: StockBasic/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockBasic stockBasic = db.stock_basic.Find(id);
            if (stockBasic == null)
            {
                return HttpNotFound();
            }
            return View(stockBasic);
        }

        // POST: StockBasic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code,name,industry,area,pe,outstanding,totals,totalAssets,liquidAssets,fixedAssets,reserved,reservedPerShare,esp,bvps,pb,timeToMarket")] StockBasic stockBasic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockBasic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockBasic);
        }

        // GET: StockBasic/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockBasic stockBasic = db.stock_basic.Find(id);
            if (stockBasic == null)
            {
                return HttpNotFound();
            }
            return View(stockBasic);
        }

        // POST: StockBasic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StockBasic stockBasic = db.stock_basic.Find(id);
            db.stock_basic.Remove(stockBasic);
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
