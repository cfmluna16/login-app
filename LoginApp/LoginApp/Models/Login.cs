using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;

namespace LoginApp.Models
{
    public class Login
    {
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        public string UserPassword { get;set; }
        [DisplayName("Verify Password")]
        public string VerifyUserPassword { get; set; }
    }
}