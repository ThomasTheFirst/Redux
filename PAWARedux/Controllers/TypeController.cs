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
    public class TypeController : Controller
    {
        private PAWAContext db = new PAWAContext();

        //
        // GET: /Type/

        public ActionResult Index()
        {
            return View(db.Types.ToList());
        }

        //
        // GET: /Type/Details/5

        public ActionResult Details(int id = 0)
        {
            PAWARedux.Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // GET: /Type/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Type/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PAWARedux.Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type);
        }

        //
        // GET: /Type/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PAWARedux.Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // POST: /Type/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PAWARedux.Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type);
        }

        //
        // GET: /Type/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PAWARedux.Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // POST: /Type/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAWARedux.Models.Type type = db.Types.Find(id);
            db.Types.Remove(type);
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