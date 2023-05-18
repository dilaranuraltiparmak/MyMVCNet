using MyMVCNET.UI.Filtres;
using MyMVCNET.UI.Models;
using MyMVCNET.UI.Models.DAL;
using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        public ActionResult ToolBox002()
        {
            return View(new SoftWareWM() { ID = 1, Key = "C#", Value = "alsjdaljdladlajs" });
        }
        public ActionResult MyDropDownListFor()
        {
            //List<SehirVM> sehirler = new List<SehirVM>() {
            //    new SehirVM(){SehirID=1,SehirAdi="izmir" },
            //    new SehirVM(){SehirID=2,SehirAdi="adana" },
            //    new SehirVM(){SehirID=3,SehirAdi="ankara" }
            //};

            //ViewBag.sehirler = new SelectList(sehirler, "SehirID", "SehirAdi");

            //return View(new SehirVM() { 
            //SehirAdi="malatya",
            //SehirID=22
            //});
            return View();
        }
        [HttpPost]
        public ActionResult MyDropDownListFor(SehirVM vm)
        {
            return RedirectToAction("MyDropDownListFor");
        }
        public ActionResult Index()
        {
            // string[] hede = {"melike","bekir","berkan" };

            //viewdata view bag, temp data , tupples,object data(view)

            ViewData["isim"] = "melike";
            ViewBag.hede = "melike";
            TempData.Add("isim", "melike");

            Person p = new Person();
            p.Ad = "bekir";
            p.Soyad = "hede";

            return View(p);
            //return Json(null); ;
            //return PartialView(); 
            //return Content("");
        }
        //snipped
        public ActionResult Index2()
        {
            var hede = TempData["isim"];
            return View();
        }


        /// <summary>
        /// ad,fiyatı,stok miktarı,kategorisi,tedarikcisi
        /// kategorisi : adı ID
        /// tedarikci : adı ID 
        /// </summary>
        /// <returns></returns>
        /// 

        //action filter attribute
        //validation
        public ActionResult UrunEkle()
        {
            return View(new UrunEkleVM()
            {
                KategoriListesi = KategoriListesineDonustur(),
                TedarikciListesi = new TedarikciDAL().TedarikcileriListele().Select(a=>new SelectListItem()
                {
                    Text=a.TedarikciSirketAdi,
                    Value=a.ID.ToString()
                }).ToList()

            }) ;
        }

        [NonAction]
        private List<SelectListItem> KategoriListesineDonustur()
        {
            var liste = new KategoriDAL().KategoriGetir()
            .Select(kv => new SelectListItem { Value = kv.ID.ToString(), Text = kv.KategoriAdi })
            .ToList();
            return liste;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [CheckUser]
        public ActionResult UrunEkle(UrunEkleVM vm)
        {
            if(!ModelState.IsValid)
            {
                //varsa hata sayfasının view ya da actionuna yönlendiriniz...
                return RedirectToAction("Index");
            }

            #region MyRegion
            //bool b = new UrunDAL().UrunBilgileriyleEklemeYAP(new DBProductAddVM()
            //{
            //    UrunFiyati = vm.UrunFiyati,
            //    Kategorisi = vm.Kategorisi,
            //    StokMiktari = vm.StokMiktari,
            //    Tedarikcisi = vm.Tedarikcisi,
            //    UrunAdi = vm.UrunAdi
            //});
            // return b == true ? RedirectToAction("UrunEkle") : RedirectToAction("Index"); 
            #endregion
            return RedirectToAction(new UrunDAL().UrunBilgileriyleEklemeYAP(new DBProductAddVM()
            {
                UrunFiyati = vm.UrunFiyati,
                Kategorisi = vm.Kategorisi,
                StokMiktari = vm.StokMiktari,
                Tedarikcisi = vm.Tedarikcisi,
                UrunAdi = vm.UrunAdi
            }) == true ? "UrunEkle" : "Index");
        }




    }
}