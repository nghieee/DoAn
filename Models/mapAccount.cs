using System;
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
            var user = db.Admins.Where(m => m.User_Email == email &&  m.User_Password == password).ToList();
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
            var admins = db.Admins.ToList();
            return admins;
        }

        
    }
}