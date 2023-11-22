using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Models
{
    public class mapCustomer
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        //Lấy danh sách full khách hàng
        public List<Customer> FindAll()
        { 
            return db.Customers.ToList();
        }
        //Lấy 1 khách hàng
        public Customer GetDetail(int id)
        {
            var customer = db.Customers.Find(id);
            return customer;
        }
        //Giới hạn bao nhiêu khách hàng trên 1 trang
        public List<Customer> LoadPage(int page, int pageSize)
        {
            var list = db.Customers.ToList().Skip((page-1) * pageSize).Take(pageSize).ToList();
            return list;
        }

        //Thêm mới/Đăng ký
        public bool AddNew(Customer model)
        {
            try
            {
                db.Customers.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Lấy đối tượng theo ID
        public Customer Detail(int Cus_ID)
        {
            return db.Customers.Find(Cus_ID);
        }

        //Update
        public bool Update(Customer model)
        {
            var cus = db.Customers.Find(model.Cus_ID);
            cus.Cus_Status = model.Cus_Status;
            db.SaveChanges();
            return true;
        }

        //Xóa
        public void Delete(int Cus_ID)
        {
            var cus = db.Customers.Find(Cus_ID);
            db.Customers.Remove(cus);
            db.SaveChanges();
        }
    }
}