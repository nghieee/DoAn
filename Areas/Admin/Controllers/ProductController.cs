using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult FindAll()
        {
            var map = new mapProduct();
            return View(map.FindAll());
        }
        //Xem chi tiết
        public ActionResult GetDetail(int Product_ID)
        {
            var product = new mapProduct().Detail(Product_ID);
            return View(product);
        }
        //Thêm mới
        public ActionResult AddNew()
        {
            return View(new Product());
        }
        //Hàm lưu thêm 
        [HttpPost]
        public ActionResult AddNew(Product model)
        {
            var map = new mapProduct();
            var id = map.AddNew(model);
            if (id > 0) return RedirectToAction("FindAll");
            else
            {
                ModelState.AddModelError("", "Lỗi thêm dữ liệu, vui lòng thử lại!");
                return View(model);
            }
        }
        //Form nhập liệu cập nhật
        public ActionResult Update(int Product_ID)
        {
            var product = new mapProduct().Detail(Product_ID);
            return View(product);
        }
        //Hàm lưu cập nhật
        [HttpPost]
        public ActionResult Update(Product model)
        {
            var map = new mapProduct();
            //Hàm cập nhật: được => true, lỗi => false
            if (map.Update(model) == true)
            {
                return RedirectToAction("FindAll");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Delete(int Product_ID)
        {
            var map = new mapProduct();
            map.Delete(Product_ID);
            return RedirectToAction("FindAll");
        }
    }
}