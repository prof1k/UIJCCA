using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DomainModel.Entity;
using DomainModel.Manager;
using DomainModel.Data;

namespace UIJCCA.web.Controllers
{
    public class ApiICCController : ApiController
    {
        private readonly GenericManager<ICC> repository;
        private DataContext db = new DataContext();
        // GET: api/ApiICC
        public ApiICCController()
        {
            repository = new GenericManager<ICC>(db);
        }
        public IEnumerable<ICC> Get()
        {
            return repository.GetAll();
        }

        // GET: api/ApiICC/5
        public ICC Get(int id)
        {
            return repository.FindBy(x => x.idObject == id).FirstOrDefault();
        }

        // POST: api/ApiICC
        public void Post([FromBody]ICC ind)
        {
            repository.Add(ind);
            repository.Save();
        }

        // PUT: api/ApiICC/5
        public void Put(int id, [FromBody]ICC ind)
        {
            repository.Edit(ind);
        }

        // DELETE: api/ApiICC/5
        public void Delete(int id)
        {
            repository.Delete(repository.FindBy(x => x.idObject == id).FirstOrDefault());
        }
    }
}
