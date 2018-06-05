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
    public class LastMileTypesController : Controller
    {
        private readonly GenericManager<LastMileType> GM;
        private DataContext db = new DataContext();

        public LastMileTypesController()
        {
            GM = new GenericManager<LastMileType>(db);
        }

        // GET: LastMileTypes
        public ActionResult Index()
        {
            return View(GM.GetAll());
        }

        // GET: LastMileTypes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastMileType lastMileType = GM.FindBy(x=>x.lastMileType == id).FirstOrDefault();
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
        public ActionResult Create([Bind(Include = "lastMileType")] LastMileType itemlastMileType)
        {
            if (ModelState.IsValid)
            {
                GM.Add(itemlastMileType);
                GM.Save();
                return RedirectToAction("Index");
            }

            return View(itemlastMileType);
        }

        // GET: LastMileTypes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastMileType lastMileType = GM.FindBy(x=>x.lastMileType == id).FirstOrDefault();
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
        public ActionResult Edit([Bind(Include = "lastMileType")] LastMileType itemlastMileType)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(itemlastMileType).State = EntityState.Modified;
                GM.Edit(itemlastMileType);
                GM.Save();
                return RedirectToAction("Index");
            }
            return View(itemlastMileType);
        }

        // GET: LastMileTypes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastMileType lastMileType = GM.FindBy(x=>x.lastMileType == id).FirstOrDefault();
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
            LastMileType lastMileType = GM.FindBy(x => x.lastMileType == id).FirstOrDefault();
            GM.Delete(lastMileType);
            GM.Save();
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
