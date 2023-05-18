using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Models.DAL
{
    public class UrunDAL
    {
        NorthwindEntities db = new NorthwindEntities();

        public bool UrunBilgileriyleEklemeYAP(DBProductAddVM vm)
        {
            //db ye git urunu vm tipine gore ekle..
            db.Products.Add(new Product()
            {
                CategoryID = vm.Kategorisi,
                ProductName = vm.UrunAdi,
                UnitsInStock = vm.StokMiktari,
                SupplierID = vm.Tedarikcisi,
                UnitPrice = vm.UrunFiyati
            });
             return db.SaveChanges() > 0;
           // return db.SaveChanges();
        }


    }
}