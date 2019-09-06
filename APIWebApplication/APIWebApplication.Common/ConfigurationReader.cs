using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace APIWebApplication.Common
{
    public class ConfigurationReader
    {

    
         public static string ConnectionString
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Data Source=.\\;Initial Catalog=ASPCRUD;Integrated Security=True");
            }
        }
    }
}
