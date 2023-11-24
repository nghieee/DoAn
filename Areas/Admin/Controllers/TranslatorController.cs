using DoAn.App_Start;
using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class TranslatorController : Controller
    {
        // GET: Admin/Translator
        public ActionResult FindAll()
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            var map = new mapTranslator();
            return View(map.FindAll());
        }

        //Thêm
        public ActionResult AddNew()
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            return View(new Translator());
        }
        [HttpPost]
        public ActionResult AddNew(Translator model)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapTranslator();
            var id = map.AddNew(model);
            if (id > 0) return RedirectToAction("FindAll");
            else
            {
                ModelState.AddModelError("", "Lỗi thêm dữ liệu, vui lòng thử lại!");
                return View(model);
            }
        }

        //Cập nhật
        public ActionResult Update(int Translator_ID)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }

            var translator = new mapTranslator().Detail(Translator_ID);
            return View(translator);
        }
        //Hàm lưu
        [HttpPost]
        public ActionResult Update(Translator model)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapTranslator();
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
        public ActionResult Delete(int Translator_ID)
        {
            var admin = SessionConfig.GetAdmin();
            if (admin == null)
            {
                return Redirect("/User/Login");
            }
            var map = new mapTranslator();
            map.Delete(Translator_ID);
            return RedirectToAction("FindAll");
        }
    }
}