using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace APIWebApplication.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string FirstName { get; set;}

        public string LastName { get; set; }

        public string Mobile { get; set; }



    }

    public class ReadContact : Contact
    {
        public ReadContact(DataRow row)
        {
            ContactID = Convert.ToInt32(row["ContactID"]);
            FirstName = row["FirstName"].ToString();
            LastName = row["LastName"].ToString();
            Mobile = row["Mobile"].ToString();
        }
    }
}