using DoAn.App_Start;
using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult FindAll()
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            mapOrder map = new mapOrder();
            return View(map.FindAll());
        }
        //Form nhập liệu cập nhật
        public ActionResult Update(int Order_ID)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            var order = new mapOrder().Detail(Order_ID);
            return View(order);
        }
        //Hàm lưu
        [HttpPost]
        public ActionResult Update(Order model)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapOrder();
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
        public ActionResult Delete(int Order_ID)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapOrder();
            map.Delete(Order_ID);
            return RedirectToAction("FindAll");
        }
    }
}