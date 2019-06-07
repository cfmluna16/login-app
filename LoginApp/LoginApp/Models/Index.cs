using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginApp.Models
{
    public class Index
    {
        public Login Login { get; set; }
        public string SessionKey { get; set; }
    }
}