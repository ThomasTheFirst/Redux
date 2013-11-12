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
    public class ImageController : Controller
    {
        private PAWAContext db = new PAWAContext();

        //
        // GET: /Image/

        public ActionResult Index()
        {
            var files = db.Files.Include(f => f.Type).Include(f => f.User).Include(f => f.Folder);
            return View(files.ToList());
        }

        //
        // GET: /Image/Details/5

        public ActionResult Details(int id = 0)
        {
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        //
        // GET: /Image/Create

        public ActionResult Create()
        {
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Extension");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username");
            ViewBag.FolderID = new SelectList(db.Folders, "FolderID", "FolderName");
            return View();
        }

        //
        // POST: /Image/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(File file)
        {
            if (ModelState.IsValid)
            {
                db.Files.Add(file);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Extension", file.TypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", file.UserID);
            ViewBag.FolderID = new SelectList(db.Folders, "FolderID", "FolderName", file.FolderID);
            return View(file);
        }

        //
        // GET: /Image/Edit/5

        public ActionResult Edit(int id = 0)
        {
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Extension", file.TypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", file.UserID);
            ViewBag.FolderID = new SelectList(db.Folders, "FolderID", "FolderName", file.FolderID);
            return View(file);
        }

        //
        // POST: /Image/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(File file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(file).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Extension", file.TypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", file.UserID);
            ViewBag.FolderID = new SelectList(db.Folders, "FolderID", "FolderName", file.FolderID);
            return View(file);
        }

        //
        // GET: /Image/Delete/5

        public ActionResult Delete(int id = 0)
        {
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        //
        // POST: /Image/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            File file = db.Files.Find(id);
            db.Files.Remove(file);
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