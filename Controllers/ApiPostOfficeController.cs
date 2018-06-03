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
    public class ApiPostOfficeController : ApiController
    {
        private readonly GenericManager<PostOffice> repository;
        private DataContext db = new DataContext();

        public ApiPostOfficeController()
        {
            repository = new GenericManager<PostOffice>(db);
        }
        // GET: api/ApiPostOffice
        public IEnumerable<PostOffice> Get()
        {
            return repository.GetAll();
        }

      // GET: api/ApiPostOffice/5
        public PostOffice Get(string id)
        {
            return repository.FindBy(x => x.postOffice == id).FirstOrDefault();
        }

        // POST: api/ApiPostOffice
        public void Post([FromBody]PostOffice ind)
        {
            repository.Add(ind);
        }

        // PUT: api/ApiPostOffice/5
        public void Put(int id, [FromBody]PostOffice ind)
        {
            repository.Edit(ind);
        }

        // DELETE: api/ApiPostOffice/5
        public void Delete(string id)
        {
            repository.Delete(repository.FindBy(x => x.postOffice == id).FirstOrDefault());
        }
    }
}
