using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class mapCategory
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        //Lấy danh sách full danh mục sản phẩm
        public List<Category> FindAll()
        {
            return db.Categories.ToList();
        }
        //Thêm mới
        public int AddNew(Category model)
        {
            db.Categories.Add(model);
            db.SaveChanges();
            return model.Cate_ID;
        }
        //Lấy đối tượng theo ID
        public Category Detail(int Cate_ID)
        {
            return db.Categories.Find(Cate_ID);
        }
        //Hmaf update
        public bool Update(Category model)
        {
            var category = db.Categories.Find(model.Cate_ID);
            category.Cate_ID = model.Cate_ID;
            category.Cate_Name = model.Cate_Name;
            db.SaveChanges();
            return true;
        }
        //Hàm xóa
        public void Delete(int Cate_ID)
        {
            var category = db.Categories.Find(Cate_ID);
            db.Categories.Remove(category);
            db.SaveChanges();
        }
    }
}