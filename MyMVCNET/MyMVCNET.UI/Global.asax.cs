using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMVCNET.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application.Add("onlineKullaniciSayisi", 0);
            Application.Add("ToplamKullaniciSayisi", 0);
        }

        protected void Application_End()
        {
            
        }

        protected void Session_End()
        {
            int online = Convert.ToInt32(Application["onlineKullaniciSayisi"]);
            online--;
            Application["onlineKullaniciSayisi"]=online;
        }

        protected void Session_Start()
        {
            int online = Convert.ToInt32(Application["onlineKullaniciSayisi"]);
            online++;
            Application["onlineKullaniciSayisi"] = online;

            int toplam = Convert.ToInt32(Application["onlineKullaniciSayisi"]);
            toplam++;
            Application["ToplamKullaniciSayisi"] = toplam;
        }

        protected void Application_BeginRequest()
        {

        }

        protected void Application_Error(object sender,EventArgs e)
        {
            Exception ex=Server.GetLastError();
            if (ex is HttpException && ((HttpException)ex).GetHashCode()==500)
            {
                //Response.Write("hata verdi");
                Response.Redirect("/MyError/Page404");
            }
        }
    }
}
