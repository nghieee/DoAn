using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult FindAll()
        {
            var map = new mapCategory();
            return View(map.FindAll());
        }
        public ActionResult AddNew()
        {
            return View(new Category());
        }
        [HttpPost]
        public ActionResult AddNew(Category model)
        {
            var map = new mapCategory();
            var id = map.AddNew(model);
            if (id > 0) return RedirectToAction("FindAll");
            else
            {
                ModelState.AddModelError("", "Lỗi thêm dữ liệu, vui lòng thử lại!");
                return View(model);
            }
        }
        //Form nhập liệu cập nhật
        public ActionResult Update(int Cate_ID)
        {
            var category = new mapCategory().Detail(Cate_ID);
            return View(category);
        }
        //Hàm lưu
        [HttpPost]
        public ActionResult Update(Category model)
        {
            var map = new mapCategory();
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
        //Xóa
        public ActionResult Delete(int Cate_ID)
        {
            var map = new mapCategory();
            map.Delete(Cate_ID);
            return RedirectToAction("FindAll");
        }
    }
}