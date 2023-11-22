using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.App_Start;
using DoAn.Models;

namespace DoAn.Controllers
{
    public class UserController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
            {
            mapAccount map = new mapAccount();
            var admin = map.Find(email, password);
            if (admin != null)
            {
                SessionConfig.SetAdmin(admin);
                ///*var*/ us = SessionConfig.GetUser();
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                //return RedirectToAction("/Admin/Dashboard/Index");
            }
            else
            {
                ViewBag.erorMessage = "Email đăng nhập hoặc mật khẩu không chính xác!!!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            SessionConfig.SetAdmin(null);
            return RedirectToAction("Login");

        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer model)
        {
            mapCustomer map = new mapCustomer();
            if (map.AddNew(model) == true)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(model);
            }
        }
    }
}