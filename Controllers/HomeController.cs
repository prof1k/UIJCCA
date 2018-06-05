using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel.Manager;
using DomainModel.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using DomainModel.Data;

namespace UIJCCA.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly GenericManager<Incidents> repository;
        private readonly GenericManager<Post> postRepository;
        private DataContext db = new DataContext();
        /*private void createRoles()
        {
            Models.ApplicationDbContext context = new Models.ApplicationDbContext();            
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Visitors"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Visitor";
                roleManager.Create(role);
            }
            if(!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }*/
        public HomeController()
        {
            repository = new GenericManager<Incidents>(db);
            postRepository = new GenericManager<Post>(db);

        }
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
                if (User.IsInRole("admin")) return View(repository.GetAll());
                        else return View(repository.FindBy(x => x.ICC.PostOffice.idpost == userManager.FindById(User.Identity.GetUserId()).idpost));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        [Authorize]
        public ActionResult AboutRoles()
        {
            IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            return View(roles);
        }
        [HttpGet]
        public ActionResult AddIncident(int? id)
        {
            if (id == null)
            {
                /*Models.IncidentsModel incidents = new Models.IncidentsModel();
                incidents.idObjectList = new ICCManager().Read().Select(x => new SelectListItem
                {                    
                    Text = x.postOffice + " (" + x.idObject.ToString() + ")",
                    Value = x.idObject.ToString()
                });*/
                Incidents incidents = new Incidents();
                return View(incidents);
            }
            else
            {
                /*var itemIncident = new IncidentsManager().GetById(Convert.ToInt32(id));
                Models.IncidentsModel incidents = new Models.IncidentsModel(itemIncident);
                incidents.idObjectList = new ICCManager().Read().Select(x => new SelectListItem
                {
                    Text = x.postOffice + " (" + x.idObject.ToString() + ")",
                    Value = x.idObject.ToString()
                });*/
                //Incidents incidents = new IncidentsManager().GetById(Convert.ToInt32(id));
                return View(repository.FindBy(x => x.idIncident == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult AddIncident(Models.IncidentsModel item)
        {
            if (ModelState.IsValid)
            {
                var itemIncident = new Incidents();
                itemIncident = item;
                itemIncident.timestamp = Convert.ToDateTime(DateTime.Now.ToString());
                if (item.idIncident == 0)
                {
                    /*var result = new IncidentsManager().Create(itemIncident);
                    ViewBag.Message = result.msg;*/
                    repository.Add(item);
                    repository.Save();
                }
                else
                {
                    //var result = new IncidentsManager().Update(itemIncident);
                    //ViewBag.Message = result.msg;
                    repository.Edit(itemIncident);
                    repository.Save();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(item);
            }
        }
        [HttpGet]
        public ActionResult EditPost(string id)
        {
            Models.PostModel postModel = new Models.PostModel();
            var itemsPosts = postRepository.GetAll();//new PostManager().Read();            
            postModel.postList = itemsPosts.Select(x => new SelectListItem
            {
                Text = x.post,
                Value = x.post
            });            
            if (id == null || id == "")
            {                
                return View(postModel);
            }
            else
            {
                postModel.post = postRepository.FindBy(x => x.post == id.ToString()).FirstOrDefault().post;// new PostManager().GetById(id.ToString()).post;
                return View(postModel);
            }
        }
        [HttpPost]
        public ActionResult EditPost(Models.PostModel item)
        {            
            if (ModelState.IsValid)
            {
                var getByid = postRepository.FindBy(x => x.post == item.post).FirstOrDefault().post;//new PostManager().GetById(item.post).post;
                if (getByid == "" || getByid == null)
                {
                    var result = postRepository.Add(new Post { post = item.post });//new PostManager().Create(new Post { post = item.post });
                    //ViewBag.Message = result.msg;
                }
                else
                {
                    var result = postRepository.Edit(new Post { post = item.post });//new PostManager().Update(new Post { post = item.post });
                    ///ViewBag.Message = result.msg;
                }
                return RedirectToAction("EditPost", "Home");
            }
            else
            {
                return View(item);
            }
        }

        public ActionResult EditPostOffice()
        {
            return View();
        }
        public ActionResult EditICC()
        {
            return View();
        }
        public ActionResult EditTypesOfService()
        {
            return View();
        }
        public ActionResult EditLastMileType()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}