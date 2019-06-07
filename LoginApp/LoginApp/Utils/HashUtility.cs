using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;

namespace LoginApp.Utils
{
    public class HashUtility
    {
        public static string ComputeSHA256Hash(string rawString)
        {
            using (SHA256 shaHasher = SHA256.Create())
            {
                byte[] bytes = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(rawString));
                StringBuilder sb = new StringBuilder();
                for(var i=0; i< bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}