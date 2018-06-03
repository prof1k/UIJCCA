using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainModel.Data;
using DomainModel.Entity;

namespace UIJCCA.web.Controllers
{
    public class PostOfficesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: PostOffices
        public ActionResult Index()
        {
            var postOffice = db.PostOffice.Include(p => p.Post);
            return View(postOffice.ToList());
        }

        // GET: PostOffices/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostOffice postOffice = db.PostOffice.Find(id);
            if (postOffice == null)
            {
                return HttpNotFound();
            }
            return View(postOffice);
        }

        // GET: PostOffices/Create
        public ActionResult Create()
        {
            ViewBag.idpost = new SelectList(db.Post, "post", "post");
            return View();
        }

        // POST: PostOffices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "postOffice,postalCode,idpost")] PostOffice postOffice)
        {
            if (ModelState.IsValid)
            {
                db.PostOffice.Add(postOffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idpost = new SelectList(db.Post, "post", "post", postOffice.idpost);
            return View(postOffice);
        }

        // GET: PostOffices/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostOffice postOffice = db.PostOffice.Find(id);
            if (postOffice == null)
            {
                return HttpNotFound();
            }
            ViewBag.idpost = new SelectList(db.Post, "post", "post", postOffice.idpost);
            return View(postOffice);
        }

        // POST: PostOffices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "postOffice,postalCode,idpost")] PostOffice postOffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postOffice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idpost = new SelectList(db.Post, "post", "post", postOffice.idpost);
            return View(postOffice);
        }

        // GET: PostOffices/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostOffice postOffice = db.PostOffice.Find(id);
            if (postOffice == null)
            {
                return HttpNotFound();
            }
            return View(postOffice);
        }

        // POST: PostOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PostOffice postOffice = db.PostOffice.Find(id);
            db.PostOffice.Remove(postOffice);
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
