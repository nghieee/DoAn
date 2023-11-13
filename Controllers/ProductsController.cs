using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
namespace DoAn.Controllers
{
    public class ProductsController : Controller
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        // GET: Products
        public ActionResult Index(int id)
        {
            ProductDetail ketQua = db.ProductDetails.Find(id);
            return View(ketQua);
        }
    }
}