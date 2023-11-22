using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAn.Models;

namespace DoAn.App_Start
{
    public class SessionConfig
    {
        //Lưu user
        public static void SetAdmin(Admin admin)
        {
            //Lưu vào session
            HttpContext.Current.Session["admin"] = admin;
        }
        public static Admin GetAdmin()
        {
            return (Admin)HttpContext.Current.Session["admin"];
        }
    }
}