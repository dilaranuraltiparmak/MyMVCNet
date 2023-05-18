using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Models.VM
{
    public class KategoriVM
    {
        public int ID { get; set; }
        //[Display(Name ="Kategori Adını Giriniz.")]
        public string KategoriAdi { get; set; }
    }
}