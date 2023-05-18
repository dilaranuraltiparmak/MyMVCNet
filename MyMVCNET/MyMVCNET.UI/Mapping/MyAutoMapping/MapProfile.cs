using AutoMapper;
using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Mapping.MyAutoMapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CustomerVM, Customer>();
            CreateMap<Customer, CustomerVM>();


            CreateMap<Order_Detail, OrderDetailVM>();
            CreateMap<OrderDetailVM, Order_Detail>();

        }
    }
}