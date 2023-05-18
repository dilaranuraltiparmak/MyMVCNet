using MyMVCNET.UI.Models.DAL;
using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MyMVCNET.UI.Controllers
{
    public class MyCacheController : Controller
    {
        // GET: MyCache
        public ActionResult Hede()
        {
            var dbdekiDatalar = new KategoriDAL().KategoriGetir();
            HttpContext.Cache.Insert("kategorilerim", dbdekiDatalar, null, DateTime.Now.AddDays(3), System.Web.Caching.Cache.NoSlidingExpiration);//3. gün sonunda cache bozulur. bir şeyin süresi ya absolitingdir ya da expiraitonsdur

            return View();
        }

        public ActionResult Index()
        {
            return View(HttpContext.Cache["kategorilerim"]as LinkedList<KategoriVM>);
        }

        public ActionResult XMLDepedencySerializer()
        {
            List<KategoriVM> dbdekiDatalar = new KategoriDAL().KategoriGetir();
            XmlSerializer xml = new XmlSerializer(typeof(List<KategoriVM>));

            StreamWriter str = new StreamWriter(Server.MapPath("~/App_Data/kategoriler.xml"));
            xml.Serialize(str, dbdekiDatalar);
            str.Close();
            return RedirectToAction("XMLDepedency");

        }


            public ActionResult XMLDepedency()
             {
            if (HttpContext.Cache["benimKategoriler"]==null)
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<KategoriVM>));
                StreamReader str = new StreamReader(Server.MapPath("~/App_Data/kategoriler.xml"));

                
                List<KategoriVM> donusturulmusData = (List<KategoriVM>)xml.Deserialize(str);
                
                str.Close();
              

                HttpContext.Cache.Insert("benimKategoriler", donusturulmusData, new CacheDependency(Server.MapPath("~/App_Data/kategoriler.xml")));
            }
            
            return View(HttpContext.Cache["benimKategoriler"]as List<KategoriVM>);
        }
    }
}