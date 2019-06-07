using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;

namespace LoginApp
{
    public class AppSettings
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LoginAppDB"].ToString();
            }
        }

        public static string PasswordSalt
        {
            get
            {
                return ConfigurationManager.AppSettings["PasswordSalt"].ToString();
            }
        }
    }
}