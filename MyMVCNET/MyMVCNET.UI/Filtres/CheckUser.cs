using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Filtres
{


    public class CheckUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);

            //if (HttpContext.Current.Session["veri"]!=null)
            if (filterContext.ActionParameters["vm"]!=null) 
            {
                var urldekiDegisken=filterContext.ActionParameters["vm"] as UrunEkleVM;

                TcKimlikSorgula.KPSPublicSoapClient sorgula = new TcKimlikSorgula.KPSPublicSoapClient();
               bool boyleBirVatandasVarMi= sorgula.TCKimlikNoDogrula(1234567890, "hüseyin", "özgüven", 1999);






                //db ye gidip sessiondaki değere göre bir karşılastırma yap
                if (urldekiDegisken.StokMiktari==1 && urldekiDegisken.UrunAdi=="asd")
                {
                    HttpContext.Current.Session.Add("deger", "asdasda");
                }
                else
                {
                    //log al
                    //nlog ?? db ye log al
                    filterContext.Result = new RedirectResult("/Home/Index");
                }
            }
        }
    }

}