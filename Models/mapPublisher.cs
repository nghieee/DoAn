using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace DoAn.Models
{
    public class mapPublisher
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        //Lấy danh sách full
        public List<Publisher> FindAll()
        {
            return db.Publishers.ToList();
        }
        //Thêm mới
        public int AddNew(Publisher model)
        {
            db.Publishers.Add(model);
            db.SaveChanges();
            return model.Publisher_ID;
        }
        //Lấy đối tượng theo ID
        public Category Detail(int Publisher_ID)
        {
            return db.Categories.Find(Publisher_ID);
        }
        //Hmaf update
        public bool Update(Publisher model)
        {
            var publisher = db.Publishers.Find(model.Publisher_ID);
            publisher.Publisher_ID = model.Publisher_ID;
            publisher.Publisher_Name = model.Publisher_Name;
            db.SaveChanges();
            return true;
        }
        //Hàm xóa
        public void Delete(int Publisher_ID)
        {
            var publisher = db.Publishers.Find(Publisher_ID);
            db.Publishers.Remove(publisher);
            db.SaveChanges();
        }
    }
}