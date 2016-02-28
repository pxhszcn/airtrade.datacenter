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
    public class StockIndexController : Controller
    {
        private StockDataDbContext db = new StockDataDbContext();

        // GET: StockIndex
        public ActionResult Index()
        {
            return View(db.stock_index.ToList());
        }

        // GET: StockIndex/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIndex stockIndex = db.stock_index.Find(id);
            if (stockIndex == null)
            {
                return HttpNotFound();
            }
            return View(stockIndex);
        }

        // GET: StockIndex/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockIndex/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code,name,change,open,preclose,close,high,low,volume,amount")] StockIndex stockIndex)
        {
            if (ModelState.IsValid)
            {
                db.stock_index.Add(stockIndex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockIndex);
        }

        // GET: StockIndex/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIndex stockIndex = db.stock_index.Find(id);
            if (stockIndex == null)
            {
                return HttpNotFound();
            }
            return View(stockIndex);
        }

        // POST: StockIndex/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code,name,change,open,preclose,close,high,low,volume,amount")] StockIndex stockIndex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockIndex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockIndex);
        }

        // GET: StockIndex/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIndex stockIndex = db.stock_index.Find(id);
            if (stockIndex == null)
            {
                return HttpNotFound();
            }
            return View(stockIndex);
        }

        // POST: StockIndex/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StockIndex stockIndex = db.stock_index.Find(id);
            db.stock_index.Remove(stockIndex);
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
