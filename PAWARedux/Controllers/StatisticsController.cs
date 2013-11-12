using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWARedux.Models;

namespace PAWARedux.Controllers
{
    public class StatisticsController : Controller
    {
        private PAWAContext db = new PAWAContext();

        //
        // GET: /Statistics/

        public ActionResult Index()
        {
            return View(db.DailyStatistics.ToList());
        }

        //
        // GET: /Statistics/Details/5

        public ActionResult Details(int id = 0)
        {
            DailyStatistics dailystatistics = db.DailyStatistics.Find(id);
            if (dailystatistics == null)
            {
                return HttpNotFound();
            }
            return View(dailystatistics);
        }

        //
        // GET: /Statistics/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Statistics/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DailyStatistics dailystatistics)
        {
            if (ModelState.IsValid)
            {
                db.DailyStatistics.Add(dailystatistics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dailystatistics);
        }

        //
        // GET: /Statistics/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DailyStatistics dailystatistics = db.DailyStatistics.Find(id);
            if (dailystatistics == null)
            {
                return HttpNotFound();
            }
            return View(dailystatistics);
        }

        //
        // POST: /Statistics/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DailyStatistics dailystatistics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailystatistics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dailystatistics);
        }

        //
        // GET: /Statistics/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DailyStatistics dailystatistics = db.DailyStatistics.Find(id);
            if (dailystatistics == null)
            {
                return HttpNotFound();
            }
            return View(dailystatistics);
        }

        //
        // POST: /Statistics/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyStatistics dailystatistics = db.DailyStatistics.Find(id);
            db.DailyStatistics.Remove(dailystatistics);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}