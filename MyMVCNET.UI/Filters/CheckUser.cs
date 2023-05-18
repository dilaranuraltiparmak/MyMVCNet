using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Filters
{
    public class CheckUser:ActionFilterAttribute
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        
            base.OnActionExecuting(filterContext);
            //if (HttpContext.Current.Session["veri"]!=null)
            if (filterContext.ActionParameters["vm"] != null)
            {
                var urldekiDegisken = filterContext.ActionParameters["vm"] as UrunEkleVM;
                //dbye gidip sessiondaki degere gore bir karsilastirma yap
                TCKimlikSorgula.KPSPublicSoapClient sorgula = new TCKimlikSorgula.KPSPublicSoapClient();
         bool boyleBirVatandaVarMi= sorgula.TCKimlikNoDogrula(12345678910, "dilara", "altipstmak", 1999);
                if (urldekiDegisken.StokMiktari == 1 && urldekiDegisken.UrunAdi == "asd")
                {
                    HttpContext.Current.Session.Add("deger", "asdad");
                }

                else
                {
                    //log al..
                    //nlog ??dbye log al
                    logger.Error("UrunEkleVM'de hatalı veri: StokMiktari={0}, UrunAdi={1}", urldekiDegisken.StokMiktari, urldekiDegisken.UrunAdi);
             
                    filterContext.Result = new RedirectResult("/Home/index");
                }

                    }
            }
        }
    }
