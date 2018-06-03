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
    public class ICCController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ICC
        public ActionResult Index()
        {
            var iCC = db.ICC.Include(i => i.LastMileType).Include(i => i.PostOffice).Include(i => i.TypeOfService);
            return View(iCC.ToList());
        }

        // GET: ICC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICC iCC = db.ICC.Find(id);
            if (iCC == null)
            {
                return HttpNotFound();
            }
            return View(iCC);
        }

        // GET: ICC/Create
        public ActionResult Create()
        {
            ViewBag.idlastMileType = new SelectList(db.LastMileType, "lastMileType", "lastMileType");
            ViewBag.idpostOffice = new SelectList(db.PostOffice, "postOffice", "idpost");
            ViewBag.idtypeOfService = new SelectList(db.TypeOfService, "typeOfService", "typeOfService");
            return View();
        }

        // POST: ICC/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idObject,idtypeOfService,internetSpeed,idlastMileType,idpostOffice")] ICC iCC)
        {
            if (ModelState.IsValid)
            {
                db.ICC.Add(iCC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idlastMileType = new SelectList(db.LastMileType, "lastMileType", "lastMileType", iCC.idlastMileType);
            ViewBag.idpostOffice = new SelectList(db.PostOffice, "postOffice", "idpost", iCC.idpostOffice);
            ViewBag.idtypeOfService = new SelectList(db.TypeOfService, "typeOfService", "typeOfService", iCC.idtypeOfService);
            return View(iCC);
        }

        // GET: ICC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICC iCC = db.ICC.Find(id);
            if (iCC == null)
            {
                return HttpNotFound();
            }
            ViewBag.idlastMileType = new SelectList(db.LastMileType, "lastMileType", "lastMileType", iCC.idlastMileType);
            ViewBag.idpostOffice = new SelectList(db.PostOffice, "postOffice", "idpost", iCC.idpostOffice);
            ViewBag.idtypeOfService = new SelectList(db.TypeOfService, "typeOfService", "typeOfService", iCC.idtypeOfService);
            return View(iCC);
        }

        // POST: ICC/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idObject,idtypeOfService,internetSpeed,idlastMileType,idpostOffice")] ICC iCC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idlastMileType = new SelectList(db.LastMileType, "lastMileType", "lastMileType", iCC.idlastMileType);
            ViewBag.idpostOffice = new SelectList(db.PostOffice, "postOffice", "idpost", iCC.idpostOffice);
            ViewBag.idtypeOfService = new SelectList(db.TypeOfService, "typeOfService", "typeOfService", iCC.idtypeOfService);
            return View(iCC);
        }

        // GET: ICC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICC iCC = db.ICC.Find(id);
            if (iCC == null)
            {
                return HttpNotFound();
            }
            return View(iCC);
        }

        // POST: ICC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ICC iCC = db.ICC.Find(id);
            db.ICC.Remove(iCC);
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
