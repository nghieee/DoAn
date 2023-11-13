using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Controllers
{
    public class CollectionsController : Controller
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        // GET: Collections
        public ActionResult Lich2024()
        {
            List<Product> ketQua = db.Products.ToList();
            return View();
        }

        public ActionResult Page2() 
        {
            return View();
        }
    }
}