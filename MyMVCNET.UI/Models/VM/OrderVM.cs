using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Models.VM
{
    public class OrderVM
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public decimal Freight { get; set; }
        public int EmployeeID { get; set; }
        
        public decimal TotalPrice { get; set; }
    }
}