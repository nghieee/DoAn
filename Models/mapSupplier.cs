using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class mapSupplier
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        //Lấy danh sách các supplier đang có
        public List<Supplier> FindAll()
        {
            return db.Suppliers.ToList();
        }
        //Thêm mới
        public int AddNew(Supplier model)
        {
            db.Suppliers.Add(model);
            db.SaveChanges();
            return model.Supplier_ID;
        }
        //Lấy đối tượng theo ID
        public Supplier Detail(int Supplier_ID)
        {
            return db.Suppliers.Find(Supplier_ID);
        }
        //Hmaf update
        public bool Update(Supplier model)
        {
            var supplier = db.Suppliers.Find(model.Supplier_ID);
            supplier.Supplier_ID = model.Supplier_ID;
            supplier.Supplier_Name = model.Supplier_Name;
            db.SaveChanges();
            return true;
        }
        //Hàm xóa
        public void Delete(int Sup_ID)
        {
            var supplier = db.Suppliers.Find(Sup_ID);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
        }
    }
}