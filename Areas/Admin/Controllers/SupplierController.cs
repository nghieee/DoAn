using DoAn.App_Start;
using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Admin/Supplier
        public ActionResult FindAll()
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            mapSupplier map = new mapSupplier();
            return View(map.FindAll());
        }

        //Thêm mới
        public ActionResult AddNew()
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            return View(new Supplier());
        }
        [HttpPost]
        public ActionResult AddNew(Supplier model)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapSupplier();
            var id = map.AddNew(model);
            if (id > 0) return RedirectToAction("FindAll");
            else
            {
                ModelState.AddModelError("", "Lỗi thêm dữ liệu, vui lòng thử lại!");
                return View(model);
            }
        }

        //Form nhập liệu cập nhật
        public ActionResult Update(int Supplier_ID)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            var order = new mapSupplier().Detail(Supplier_ID);
            return View(order);
        }
        //Hàm lưu
        [HttpPost]
        public ActionResult Update(Supplier model)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapSupplier();
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
        public ActionResult Delete(int Supplier_ID)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapSupplier();
            map.Delete(Supplier_ID);
            return RedirectToAction("FindAll");
        }
    }
}