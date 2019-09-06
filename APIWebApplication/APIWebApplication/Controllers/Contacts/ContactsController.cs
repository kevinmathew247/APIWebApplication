using APIWebApplication.Models;
using APIWebApplication.Processors;
using APIWebApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace APIWebApplication.Controllers.Contacts
{
  [ AllowAnonymous]  
    [RoutePrefix("api/Contact")]
    public class ContactsController : ApiController
    {
        ContactProcessor obj = new ContactProcessor();
        [HttpPost]
        [Route("SaveContact")]
        public bool SaveContact(Contact contact)

        {
            if (contact == null)
            {
                return false;
            }
             

            return obj.ProcessContact(contact);

        }

        [HttpGet]
        [Route("GetContact")]
        public IEnumerable<Contact> GetContact(int id)

        {


            return obj.DisplayContact(id);
            
        }

        [HttpGet]
        [Route("GetContactList")]
        public IEnumerable<Contact> GetContact()
        { 
            return obj.DisplayContact();

        }



    }
}
