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
    public class PostsController : Controller
    {
        private readonly GenericManager<Post> GM;
        private DataContext db = new DataContext();

        public PostsController()
        {
            GM = new GenericManager<Post>(db);
        }
        // GET: Posts
        public ActionResult Index()
        {
            return View(GM.GetAll());
        }

        // GET: Posts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = GM.FindBy(x=> x.post == id).First();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "post")] Post postitem)
        {
            if (ModelState.IsValid)
            {
                if (GM.Add(postitem))
                    if (GM.Save())
                        return RedirectToAction("Index");
            }

            return View(postitem);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = GM.FindBy(x=>x.post == id).First();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "post")] Post postitem)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(post).State = EntityState.Modified;
                //db.SaveChanges();
                if (GM.Edit(postitem))
                    if (GM.Save())
                        return RedirectToAction("Index");
            }
            return View(postitem);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = GM.FindBy(x => x.post == id).First();//db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Post post = GM.FindBy(x=>x.post == id).First();
            GM.Delete(post);
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
