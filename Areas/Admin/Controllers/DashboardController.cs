using DoAn.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            return View();
        }
    }
}