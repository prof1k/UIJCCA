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
    public class ApiIncidentsController : ApiController
    {
        private readonly GenericManager<Incidents> repository;
        private DataContext db = new DataContext();

        public ApiIncidentsController()
        {
            repository = new GenericManager<Incidents>(db);
        }
        // GET: api/ApiIncidents
        public IEnumerable<Incidents> Get()
        {
            return repository.GetAll();
        }

        // GET: api/ApiIncidents/5
        public Incidents Get(int id)
        {
            return repository.FindBy(x => x.idIncident == id).FirstOrDefault();
        }

        // POST: api/ApiIncidents
        public void Post([FromBody]Incidents ind)
        {
            repository.Add(ind);
        }

        // PUT: api/ApiIncidents/5
        public void Put(int id, [FromBody]Incidents ind)
        {
            repository.Edit(ind);
        }

        // DELETE: api/ApiIncidents/5
        public void Delete(int id)
        {
            repository.Delete(repository.FindBy(x => x.idIncident == id).FirstOrDefault());
        }
    }
}
