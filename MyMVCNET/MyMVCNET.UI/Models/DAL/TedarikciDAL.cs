using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Models.DAL
{
    public class TedarikciDAL
    {NorthwindEntities db = new NorthwindEntities();
        public List<TedarikciVM> TedarikcileriListele()
        {
            return db.Suppliers.Select(a=> new TedarikciVM()
            {
                ID=a.SupplierID,
                TedarikciSirketAdi=a.CompanyName
            }).ToList();
        }
    }
}