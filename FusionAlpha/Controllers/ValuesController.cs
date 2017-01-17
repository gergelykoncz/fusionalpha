using DataAccess.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace FusionAlpha.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IRepository<Patient> _repo;

        public ValuesController(IRepository<Patient> repo)
        {
            this._repo = repo;
        }
        // GET api/values
        public IEnumerable<Patient> Get()
        {
            return this._repo.GetAll();
        }

        // GET api/values/5
        public Patient Get(int id)
        {
            return this._repo.Get(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
