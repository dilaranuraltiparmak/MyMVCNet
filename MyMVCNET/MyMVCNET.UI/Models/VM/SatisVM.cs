using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Models.VM
{
    public class SatisVM
    {
        public OrderVM OrderInfo { get; set; }
        public OrderDetailVM OrderdetailInfo { get; set; }

        public List<SelectListItem> Customers { get; set; }
        public List<SelectListItem> Emplooyes { get; set; }
        public List<SelectListItem> Shippers { get; set; }
        public List<SelectListItem> Products { get; set; }

    }
}