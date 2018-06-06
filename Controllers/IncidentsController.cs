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
using DomainModel.Manager;

namespace UIJCCA.web.Controllers
{
    public class IncidentsController : Controller
    {
        private DataContext db = new DataContext();
        private readonly GenericManager<Incidents> GM;

        public IncidentsController()
        {
            GM = new GenericManager<Incidents>(db);
        }
        // GET: Incidents
        public ActionResult Index()
        {
            //var incidents = db.Incidents.Include(i => i.ICC);
            var incidents = GM.GetAll().Include(i => i.ICC);
            return View(incidents.ToList());
        }

        // GET: Incidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidents incidents = GM.FindBy(x=>x.idIncident == id).FirstOrDefault();
            if (incidents == null)
            {
                return HttpNotFound();
            }
            return View(incidents);
        }

        // GET: Incidents/Create
        public ActionResult Create()
        {
            ViewBag.idObject = new SelectList(db.ICC, "idObject", "idpostOffice"); // idtypeOfService
            return View();
        }

        // POST: Incidents/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idIncident,idObject,incidentOpening,IncidentClose,incidentNumberIteko,incidentNumberRT,description,timestamp")] Incidents incidents)
        {
            if (ModelState.IsValid)
            {
                GM.Add(incidents);
                GM.Save();
                return RedirectToAction("Index");
            }

            ViewBag.idObject = new SelectList(db.ICC, "idObject", "idpostOffice", incidents.idObject);
            return View(incidents);
        }

        // GET: Incidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidents incidents = GM.FindBy(x=>x.idIncident == id).FirstOrDefault();
            if (incidents == null)
            {
                return HttpNotFound();
            }
            ViewBag.idObject = new SelectList(db.ICC, "idObject", "idpostOffice", incidents.idObject);
            return View(incidents);
        }

        // POST: Incidents/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idIncident,idObject,incidentOpening,IncidentClose,incidentNumberIteko,incidentNumberRT,description,timestamp")] Incidents incidents)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(incidents).State = EntityState.Modified;
                GM.Edit(incidents);
                GM.Save();
                return RedirectToAction("Index");
            }
            ViewBag.idObject = new SelectList(db.ICC, "idObject", "idpostOffice", incidents.idObject);
            return View(incidents);
        }

        // GET: Incidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidents incidents = GM.FindBy(x=>x.idIncident == id).FirstOrDefault();
            if (incidents == null)
            {
                return HttpNotFound();
            }
            return View(incidents);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incidents incidents = GM.FindBy(x=>x.idIncident == id).FirstOrDefault();
            db.Incidents.Remove(incidents);
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
