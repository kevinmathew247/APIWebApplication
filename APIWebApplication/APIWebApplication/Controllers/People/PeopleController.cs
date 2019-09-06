using APIWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWebApplication.Controllers.People
{
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();
        public PeopleController()
        {

            people.Add(new Person { FirstName = "Aamy", LastName = "Mathew", Id = 1 });
            people.Add(new Person { FirstName = "Binkitha", LastName = "Mathew", Id = 2 });
            people.Add(new Person { FirstName = "Kevin", LastName = "Mathew", Id = 3});

        }
        [Route("api/People/GetFirstNames")]
        [HttpGet]
        public List<string> GetFirstNames()
        {
            List<string> output = new List<string>();

            foreach(var p in people)
            {
                output.Add(p.FirstName);
            }
            return output;
        }
        // GET: api/People
        public List<Person> Get()
        {
            return people; 
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();

        }

        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }

        //// PUT: api/People/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/People/5
        public void Delete(int id)
        {
         
        }
    }
}
