using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using APIWebApplication.Common;
using APIWebApplication.Models;
using APIWebApplication.Controllers;
using System.Data.SqlClient;

namespace APIWebApplication.Repositories
{
    public class ContactRepository
    {
       

        public  bool AddContactToDB(Contact contact)
        {
            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ASPCRUD; Integrated Security=True";

            var query = "INSERT INTO ContactDetails (FirstName,LastName,Mobile) VALUES('@FirstName', '@LastName', '@Mobile')";

            query = query.Replace("@FirstName", contact.FirstName).Replace("@LastName", contact.LastName).Replace("@Mobile", contact.Mobile);

            SqlConnection connection = new SqlConnection(connectionString);

                try
                {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        
                        command.ExecuteNonQuery();
                        command.Dispose();
                return true;


            }
                catch
                {
                    return false;
                }
            
        }

        public  IEnumerable<Contact> DisplayContactFromDB(int id=0)
        {
            var connectionString = "Persist Security Info=False;User ID=sa;Password=inapp2.0;Initial Catalog=ASPCRUD;Data Source=DESKTOP-QTUU77J\\SQLEXPRESS2012";
            DataTable DT = new DataTable();

            var query = string.Empty;
            if (id > 0)
            {
                query = "SELECT * FROM ContactDetails WHERE ContactID=" + id;
            }
            else
                query = "SELECT * FROM ContactDetails ";


            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(query, connection);
                command.Fill(DT);
            };
           
            List<Contact> contacts = new List<Models.Contact>(DT.Rows.Count);
            if(DT.Rows.Count > 0)
            {
                foreach (DataRow contactrecord in DT.Rows)
                {
                    contacts.Add(new ReadContact(contactrecord));
                }
            }
            return contacts;
        
        }
    }
}