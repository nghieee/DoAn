using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class mapAuthor
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        //Lấy danh sách full danh sách tác giả
        public List<Author> FindAll()
        {
            return db.Authors.ToList();
        }
        //Thêm mới
        public int AddNew(Author model)
        {
            db.Authors.Add(model);
            db.SaveChanges();
            return model.Author_ID;
        }
        //Lấy đối tượng theo ID
        public Author Detail(int Author_ID)
        {
            return db.Authors.Find(Author_ID);
        }
        //Hmaf update
        public bool Update(Author model)
        {
            var author = db.Authors.Find(model.Author_ID);
            author.Author_ID = model.Author_ID;
            author.Author_Name = model.Author_Name;
            db.SaveChanges();
            return true;
        }
        //Hàm xóa
        public void Delete(int Author_ID)
        {
            var author = db.Authors.Find(Author_ID);
            db.Authors.Remove(author);
            db.SaveChanges();
        }
    }
}