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
    public class TypeOfServiceController : Controller
    {
        private readonly GenericManager<TypeOfService> GM;
        private DataContext db = new DataContext();
        public TypeOfServiceController()
        {
            GM = new GenericManager<TypeOfService>(db);
        }

        // GET: TypeOfService
        public ActionResult Index()
        {
            return View(GM.GetAll());
        }

        // GET: TypeOfService/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfService typeOfService = GM.FindBy(x=>x.typeOfService == id).FirstOrDefault();
            if (typeOfService == null)
            {
                return HttpNotFound();
            }
            return View(typeOfService);
        }

        // GET: TypeOfService/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfService/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "typeOfService")] TypeOfService itemtypeOfService)
        {
            if (ModelState.IsValid)
            {
                GM.Add(itemtypeOfService);
                GM.Save();
                return RedirectToAction("Index");
            }

            return View(itemtypeOfService);
        }

        // GET: TypeOfService/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfService typeOfService = GM.FindBy(x=>x.typeOfService == id).FirstOrDefault();
            if (typeOfService == null)
            {
                return HttpNotFound();
            }
            return View(typeOfService);
        }

        // POST: TypeOfService/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "typeOfService")] TypeOfService itemtypeOfService)
        {
            if (ModelState.IsValid)
            {
                GM.Add(itemtypeOfService);
                GM.Save();
                return RedirectToAction("Index");
            }
            return View(itemtypeOfService);
        }

        // GET: TypeOfService/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfService typeOfService = GM.FindBy(x => x.typeOfService == id).FirstOrDefault();
            if (typeOfService == null)
            {
                return HttpNotFound();
            }
            return View(typeOfService);
        }

        // POST: TypeOfService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TypeOfService typeOfService = GM.FindBy(x => x.typeOfService == id).FirstOrDefault();
            GM.Delete(typeOfService);
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
