using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginApp.DataModels
{
    public class User
    {
        public User() { }
        public User(Login login)
        {
            UserName = login.UserName;
            UserPassword = login.UserPassword;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}