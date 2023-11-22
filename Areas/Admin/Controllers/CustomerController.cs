using DoAn.App_Start;
using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class CustomerController : Controller    
    {
        // GET: Admin/Customer
        public ActionResult FindAll()
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            var map = new mapCustomer();
            //var data = map.LoadPage(1, 15);

            return View(map.FindAll());
        }
        //Form nhập liệu cập nhật
        public ActionResult Update(int Cus_ID)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            var order = new mapCustomer().Detail(Cus_ID);
            return View(order);
        }
        //Hàm lưu
        [HttpPost]
        public ActionResult Update(Customer model)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapCustomer();
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
        public ActionResult Delete(int Cus_ID)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapCustomer();
            map.Delete(Cus_ID);
            return RedirectToAction("FindAll");
        }
    }
}