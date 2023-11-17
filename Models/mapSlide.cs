using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class mapSlide
    {
        dbNhanvanEntities db = new dbNhanvanEntities();
        public List<Slide> FindAll()
        {
            return db.Slides.ToList();
        }
    }
}