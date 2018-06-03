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
    public class LastMileTypesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: LastMileTypes
        public ActionResult Index()
        {
            return View(db.LastMileType.ToList());
        }

        // GET: LastMileTypes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastMileType lastMileType = db.LastMileType.Find(id);
            if (lastMileType == null)
            {
                return HttpNotFound();
            }
            return View(lastMileType);
        }

        // GET: LastMileTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LastMileTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lastMileType")] LastMileType lastMileType)
        {
            if (ModelState.IsValid)
            {
                db.LastMileType.Add(lastMileType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lastMileType);
        }

        // GET: LastMileTypes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastMileType lastMileType = db.LastMileType.Find(id);
            if (lastMileType == null)
            {
                return HttpNotFound();
            }
            return View(lastMileType);
        }

        // POST: LastMileTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lastMileType")] LastMileType lastMileType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lastMileType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lastMileType);
        }

        // GET: LastMileTypes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastMileType lastMileType = db.LastMileType.Find(id);
            if (lastMileType == null)
            {
                return HttpNotFound();
            }
            return View(lastMileType);
        }

        // POST: LastMileTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LastMileType lastMileType = db.LastMileType.Find(id);
            db.LastMileType.Remove(lastMileType);
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
