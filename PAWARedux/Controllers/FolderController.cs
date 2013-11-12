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
    public class FolderController : Controller
    {
        private PAWAContext db = new PAWAContext();

        //
        // GET: /Folder/

        public ActionResult Index()
        {
            var folders = db.Folders.Include(f => f.User);
            return View(folders.ToList());
        }

        //
        // GET: /Folder/Details/5

        public ActionResult Details(int id = 0)
        {
            Folder folder = db.Folders.Find(id);
            if (folder == null)
            {
                return HttpNotFound();
            }
            return View(folder);
        }

        //
        // GET: /Folder/Create

        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username");
            return View();
        }

        //
        // POST: /Folder/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Folder folder)
        {
            if (ModelState.IsValid)
            {
                db.Folders.Add(folder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", folder.UserID);
            return View(folder);
        }

        //
        // GET: /Folder/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Folder folder = db.Folders.Find(id);
            if (folder == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", folder.UserID);
            return View(folder);
        }

        //
        // POST: /Folder/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Folder folder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(folder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", folder.UserID);
            return View(folder);
        }

        //
        // GET: /Folder/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Folder folder = db.Folders.Find(id);
            if (folder == null)
            {
                return HttpNotFound();
            }
            return View(folder);
        }

        //
        // POST: /Folder/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Folder folder = db.Folders.Find(id);
            db.Folders.Remove(folder);
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