using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using DoAn.Models;

namespace DoAn.Models
{
    public class mapOrder
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        public string mesage = "";
        //Xuất danh sách tất cả đơn hàng
        public List<Order> FindAll()
        {
            return db.Orders.ToList();
        }
        //Lưu đơn hàng được add vào => trả về ID
        public int AddNew(Order model)
        {
            if (model.Order_CusID == 0)
            {
                mesage = "Thiếu thông tin khách hàng";
                return 0;
                //=> lỗi
            }
            if (model.Order_Date == null)
            {
                mesage = "Thiếu thông tin ngày đặt hàng";
            }
            db.Orders.Add(model);
            return model.Order_ID;
        }
        //Lấy đối tượng theo ID
        public Order Detail(int Order_ID)
        {
            return db.Orders.Find(Order_ID);
        }
        //Hmaf update
        public bool Update(Order model)
        {
            var order = db.Orders.Find(model.Order_ID);
            if (order == null)
            {
                mesage = "Không tìm thấy đơn hàng";
                return false;
            }
            order.Order_CusID = model.Order_CusID;
            order.Order_Date = model.Order_Date;
            order.Order_Phone = model.Order_Detail;
            order.Order_Detail = model.Order_Detail;
            order.Order_Address = model.Order_Address;
            order.Order_SubTotal = model.Order_SubTotal;
            order.Order_Discount = model.Order_Discount;
            order.Order_ShipFee = model.Order_ShipFee;
            order.Order_Total = model.Order_Total;
            if (model.Order_CusID == 0)
            {
                mesage = "Thiếu thông tin khách hàng";
                return false;
                //=> lỗi
            }
            if (model.Order_Date == null)
            {
                mesage = "Thiếu thông tin ngày đặt hàng";
                return false;
            }
            db.SaveChanges();
            return true;
        }
        //Hàm xóa
        public void Delete(int Order_ID) 
        {
            var order = db.Orders.Find(Order_ID);
            db.Orders.Remove(order);
            db.SaveChanges();
        }
    }
}