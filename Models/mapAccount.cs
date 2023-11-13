﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAn.Models;

namespace DoAn.Models
{
    public class mapAccount
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        public Admin Find(string email, string password)
        {
            var user = db.Admins.Where(m => m.Admin_Email == email &  m.Admin_Password == password).ToList();
            if (user.Count > 0)
            {
                return user[0];
            }
            else
            {
                return null;
            }
        }

        public List<Admin> FindAll()
        {
            var users = db.Admins.ToList();
            return users;
        }

        //public void AddNew(string ad_Email, string ad_Password, string ad_Name, string ad_Phone, string ad_Image)
        //{
        //    //Khởi tạo đối tương + gán giá trị
        //    Admin addNew = new Admin();
        //    addNew.Admin_Email = ad_Email;
        //    addNew.Admin_Password = ad_Password;
        //    addNew.Admin_Name = ad_Name;
        //    addNew.Admin_Phone = ad_Phone;
        //    addNew.Admin_Image = ad_Image;
        //    //Add đối tượng vào dataset entity
        //    db.Admins.Add(addNew);
        //    //Lưu vào db
        //    db.SaveChanges();
        //}

        public bool AddNew(Admin addNew)
        {
            try
            {
                //Add đối tượng vào dataset entity
                db.Admins.Add(addNew);
                //Lưu vào db
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}