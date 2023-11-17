using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class mapProduct
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        //Lấy danh sách full sản phẩm
        public List<Product> FindAll()
        {
            return db.Products.ToList();
        }
        //public Product GetDetail(int ProDe_ID)
        //{
        //    var productDetail = db.Products.Find(ProDe_ID);
        //    return productDetail;
        //}
        //Thêm mới
        public int AddNew(Product model)
        {
            db.Products.Add(model);
            db.SaveChanges();
            return model.Product_ID;
        }
        //Lấy đối tượng theo ID
        public Product Detail(int Product_ID)
        {
            return db.Products.Find(Product_ID);
        }
        //Hmaf update
        public bool Update(Product model)
        {
            var product = db.Products.Find(model.Product_ID);
            product.Product_ID = model.Product_ID;
            product.Product_Name = model.Product_Name;
            product.Product_Image = model.Product_Image;
            product.Product_OldPrice = model.Product_OldPrice;
            product.Product_NewPrice = model.Product_NewPrice;
            product.Product_Discout = model.Product_Discout;
            db.SaveChanges();
            return true;
        }
        //Hàm xóa
        public void Delete(int Product_ID)
        {
            var product = db.Products.Find(Product_ID);
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}