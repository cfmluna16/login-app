using LoginApp.DataModels;
using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Security.Cryptography;
using LoginApp.Utils;

namespace LoginApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataAccess _dataAccess;
        public HomeController()
        {
            _dataAccess = new DataAccess();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Login Page";

            Index index = new Index();

            var sessionKey = Session["SessionKey"];
            if(sessionKey != null)
            {
                index.SessionKey = sessionKey.ToString();
            }

            var loginModel = new Login();
            index.Login = loginModel;

            return View(index);
        }

        public ActionResult Login(Login login)
        {
            ViewBag.LoginErrorMessage = "";
            if(string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.UserPassword))
            {
                ViewBag.LoginErrorMessage = "Please provide User Name and Password";
                return PartialView("_LoginForm");
            }
            else
            {
                var hashedPassword = HashUtility.ComputeSHA256Hash(string.Format("{0}{1}", AppSettings.PasswordSalt, login.UserPassword));
                var user = _dataAccess.GetUser(login.UserName);

                if(user != null)
                {
                    if (user.UserPassword.Equals(hashedPassword))
                    {
                        Session["SessionKey"] = Guid.NewGuid().ToString();
                        return PartialView("_LoginSuccess");
                    }
                    else
                    {
                        ViewBag.LoginErrorMessage = "Passwords don't match";
                        return PartialView("_LoginForm");
                    }
                }
                else
                {
                    ViewBag.LoginErrorMessage = "User not found";
                    return PartialView("_LoginForm");
                }
            }
            
        }

        public ActionResult Logout()
        {
            Session["SessionKey"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            var newLogin = new Login();
            return View(newLogin);
        }

        public ActionResult SaveUser(Login newLogin)
        {
            newLogin.UserPassword = HashUtility.ComputeSHA256Hash(string.Format("{0}{1}",AppSettings.PasswordSalt,newLogin.UserPassword));
          
            var newUser = new User(newLogin);
            
            _dataAccess.CreateUser(newUser);

            return RedirectToAction("Index");
        }


    }
}
