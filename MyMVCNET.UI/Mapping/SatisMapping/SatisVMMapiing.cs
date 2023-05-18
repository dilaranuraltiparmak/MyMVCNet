using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Mapping.SatisMapping
{
    public class SatisVMMapiing
    {
        public Orders OrderVMTOOrder(OrderVM donusturulecekVMBilgisi)
        {
            return new Orders
            {
                CustomerID = donusturulecekVMBilgisi.CustomerID,
                EmployeeID = donusturulecekVMBilgisi.EmployeeID,
                Freight = donusturulecekVMBilgisi.Freight,
                RequiredDate = donusturulecekVMBilgisi.RequiredDate,
                OrderDate = donusturulecekVMBilgisi.OrderDate,
                ShipVia = donusturulecekVMBilgisi.ShipVia,
                ShippedDate = donusturulecekVMBilgisi.ShippedDate
            };

        }

        public void OrderTOOderVM()
        { }

        public void OrderDetailtoOrderDetailVM()
        { }

        public Order_Details OrderDetailtoOrderDetail(OrderDetailVM donusturulecekDetayVMBilgisi)
        {
            return new Order_Details()
            {
                OrderID = donusturulecekDetayVMBilgisi.OrderID,
                Quantity = donusturulecekDetayVMBilgisi.Quantity,
                ProductID = donusturulecekDetayVMBilgisi.ProductID,
                UnitPrice = donusturulecekDetayVMBilgisi.UnitPrice,
                Discount = donusturulecekDetayVMBilgisi.Discount,
            };
        }
    }
}