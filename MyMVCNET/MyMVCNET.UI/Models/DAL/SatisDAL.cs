using MyMVCNET.UI.Mapping.SatisMapping;
using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Transactions;
using System.Web;

namespace MyMVCNET.UI.Models.DAL
{
    public class SatisDAL
    {
        
        public void SatisYap(SatisVM vm)
        {
           using( TransactionScope scope= new TransactionScope() )
            {
                try
                {
                    using(NorthwindEntities db = new NorthwindEntities())
                    {
                        Order eklenmisSiparis=db.Orders.Add(new SatisVMMapiing().OrderVMTOOrder(vm.OrderInfo));//sipariş ekleme


                        vm.OrderdetailInfo.OrderID = eklenmisSiparis.OrderID;//siparişe göre detay ekleme
                        db.Order_Details.Add(new SatisVMMapiing().OrderDetailtoOrderDetail(vm.OrderdetailInfo));
                      

                        //stok düşürme
                        var guncellenecekUrunBilgisi = db.Products.Where(a => a.ProductID == vm.OrderdetailInfo.ProductID).SingleOrDefault();
                        guncellenecekUrunBilgisi.UnitsInStock -= vm.OrderdetailInfo.Quantity;

                        db.SaveChanges();

                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                }
            }
            
            
            
            
            //int OrderID =db.Orders.Add(new Order()
            
            //{
            //    CustomerID = vm.CustomerID,
            //    OrderDate = vm.OrderDate,
            //    RequiredDate = vm.RequiredDate,
            //    ShippedDate = vm.ShippedDate,
            //    ShipVia = vm.ShipVia,
            //    Freight = vm.Freight,
            //    EmployeeID = vm.EmployeeID
            //}).


            //db.Order_Details.Add(new Order_Detail()
            //{
            //    Discount = vm.OrderDetailInfo.Discount,
            //    ProductID = vm.OrderDetailInfo.ProductID,
            //    Quantity = vm.OrderDetailInfo.Quantity,
            //    UnitPrice = vm.OrderDetailInfo.UnitPrice,
            //});
            //db.SaveChanges();
        }

    }
}