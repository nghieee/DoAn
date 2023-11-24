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
        public ActionResult ProductDetail(int Product_ID)
        {
            var product = db.Products.Where(p => p.Product_ID == Product_ID).FirstOrDefault();

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}