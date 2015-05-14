using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPITest.Controllers
{
    public class CustomerController : ApiController
    {

        Models.CustomerDatabaseEntities de = new Models.CustomerDatabaseEntities();
        // GET api/<controller>

        public List<Models.CustomerTable> Get()
        {
            var result = from c in de.CustomerTables
                         select c;
            return result.ToList();
        }
    
        // GET api/<controller>/5
        public Models.CustomerTable Get(string id)
        {
            var resutlt = from c in de.CustomerTables
                          where c.customerID == id
                          select c;

            Models.CustomerTable ct =new Models.CustomerTable();
            foreach(var r in resutlt)
            {
                ct = r;
            }
            return ct;
        }

        // POST api/<controller>
        public void Post([FromBody]Models.CustomerTable ct)
        {
            de.CustomerTables.Add(ct);
            de.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]Models.CustomerTable ct)
        {
            var result = from c in de.CustomerTables
                         where c.customerID == id
                         select c;
            foreach (var r in result)
            {
                r.customerName = ct.customerName;
                r.customerAddress = ct.customerAddress;
            }
            de.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            var result = from c in de.CustomerTables
                         where c.customerID == id
                         select c;
            foreach (var r in result)
            {
                de.CustomerTables.Remove(r);
            }
            de.SaveChanges();
        }
    }
}