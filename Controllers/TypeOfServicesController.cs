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
    public class TypeOfServicesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: TypeOfServices
        public ActionResult Index()
        {
            return View(db.TypeOfService.ToList());
        }

        // GET: TypeOfServices/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfService typeOfService = db.TypeOfService.Find(id);
            if (typeOfService == null)
            {
                return HttpNotFound();
            }
            return View(typeOfService);
        }

        // GET: TypeOfServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfServices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "typeOfService")] TypeOfService typeOfService)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfService.Add(typeOfService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfService);
        }

        // GET: TypeOfServices/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfService typeOfService = db.TypeOfService.Find(id);
            if (typeOfService == null)
            {
                return HttpNotFound();
            }
            return View(typeOfService);
        }

        // POST: TypeOfServices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "typeOfService")] TypeOfService typeOfService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfService);
        }

        // GET: TypeOfServices/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfService typeOfService = db.TypeOfService.Find(id);
            if (typeOfService == null)
            {
                return HttpNotFound();
            }
            return View(typeOfService);
        }

        // POST: TypeOfServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TypeOfService typeOfService = db.TypeOfService.Find(id);
            db.TypeOfService.Remove(typeOfService);
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
