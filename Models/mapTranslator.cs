using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class mapTranslator
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        //Lấy danh sách full
        public List<Translator> FindAll()
        {
            return db.Translators.ToList();
        }
        //Thêm mới
        public int AddNew(Translator model)
        {
            db.Translators.Add(model);
            db.SaveChanges();
            return model.Translator_ID;
        }
        //Lấy đối tượng theo ID
        public Translator Detail(int Translator_ID)
        {
            return db.Translators.Find(Translator_ID);
        }
        //Hmaf update
        public bool Update(Translator model)
        {
            var translator = db.Translators.Find(model.Translator_ID);
            translator.Translator_ID = model.Translator_ID;
            translator.Translator_Name = model.Translator_Name;
            db.SaveChanges();
            return true;
        }
        //Hàm xóa
        public void Delete(int Translator_ID)
        {
            var translator = db.Translators.Find(Translator_ID);
            db.Translators.Remove(translator);
            db.SaveChanges();
        }
    }
}