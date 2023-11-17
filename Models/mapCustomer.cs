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

        //Thêm mới
        public int AddNew(Customer model)
        {
            db.Customers.Add(model);
            db.SaveChanges();
            return model.Cus_ID;
        }
        //Lấy đối tượng theo ID
        public Customer Detail(int Cus_ID)
        {
            return db.Customers.Find(Cus_ID);
        }
        //Hmaf update
        public bool Update(Customer model)
        {
            var cus = db.Customers.Find(model.Cus_ID);
            cus.Cus_ID = model.Cus_ID;
            cus.Cus_Name = model.Cus_Name;
            cus.Cus_Phone = model.Cus_Phone;
            cus.Cus_Address = model.Cus_Address;
            cus.Cus_BirthDate = model.Cus_BirthDate;
            cus.Cus_Status = model.Cus_Status;
            cus.Cus_Money = model.Cus_Money;
            db.SaveChanges();
            return true;
        }
        //Hàm xóa
        public void Delete(int Cus_ID)
        {
            var cus = db.Customers.Find(Cus_ID);
            db.Customers.Remove(cus);
            db.SaveChanges();
        }
    }
}