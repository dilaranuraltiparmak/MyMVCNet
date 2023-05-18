using MyMVCNET.UI.Models.VM;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Filtres
{


    public class CheckUser : ActionFilterAttribute
    {
        private static Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);

            //if (HttpContext.Current.Session["veri"]!=null)
            if (filterContext.ActionParameters["vm"]!=null) 
            {
                var urldekiDegisken=filterContext.ActionParameters["vm"] as UrunEkleVM;

                TcKimlikSorgula.KPSPublicSoapClient sorgula = new TcKimlikSorgula.KPSPublicSoapClient();
               bool boyleBirVatandasVarMi= sorgula.TCKimlikNoDogrula(1234567890, "dilara", "altıparmak", 2000);


                //db ye gidip sessiondaki değere göre bir karşılastırma yap
                if (urldekiDegisken.StokMiktari==1 && urldekiDegisken.UrunAdi=="asd")
                {
                    HttpContext.Current.Session.Add("deger", "asdasda");
                }
                else
                {
                    //log al
                    //nlog ?? db ye log ale
                    //var logger = NLog.LogManager.GetCurrentClassLogger();
                    //logger.Error("Kullanıcıdan geçersiz ürün verisi alındı. Ürün Adı: {0}, Stok Miktarı: {1}", urldekiDegisken.UrunAdi, urldekiDegisken.StokMiktari);
                    var logger = NLog.LogManager.GetCurrentClassLogger();
                    logger.Info("Ürün ekleniyor. Ürün Adı: {0}, Stok Miktarı: {1}", urldekiDegisken.UrunAdi, urldekiDegisken.StokMiktari);

                    // kullanıcıyı ana sayfaya yönlendir
                    filterContext.Result = new RedirectResult("/Home/Index");
                    }
         
                }
            }
        }
    }

