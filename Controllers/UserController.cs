using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var user = map.Find(email, password);
            if (user != null)
            {
                return RedirectToAction("Index", "Dashboard", new {area = "Admin"});
                //return RedirectToAction("/Admin/Dashboard/Index");
            }
            ViewBag.errorMessage = "Email đăng nhập hoặc mật khẩu không chính xác";
            return View();

        }
        public ActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signin(Admin model)
        {
            mapAccount map = new mapAccount();
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