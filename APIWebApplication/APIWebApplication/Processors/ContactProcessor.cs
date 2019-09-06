using APIWebApplication.Models;
using APIWebApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIWebApplication.Controllers;

namespace APIWebApplication.Processors
{
    public class ContactProcessor
    {
        ContactRepository obj = new ContactRepository();
        public  bool ProcessContact(Contact contact)
        { 
            return obj.AddContactToDB(contact);
        }
        public  IEnumerable<Contact> DisplayContact(int id=0)
        {
            return obj.DisplayContactFromDB(id);
        }


    }
}