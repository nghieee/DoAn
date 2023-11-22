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
        public ActionResult ProductDetail(int ProductID)
        {
            var productDetail = new mapProduct().ViewDetail(ProductID);
            //ViewBag.productDe = new mapProduct().ViewDetail

            if (productDetail == null)
            {
                // Xử lý khi không tìm thấy chi tiết sản phẩm
                return HttpNotFound();
            }

            return View(productDetail);
        }

    }
}