using MyMVCNET.UI.Models.VM.AccountVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyMVCNET.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        /*
         State management => cookie- clientside string tutar
        Session => statless -serverside object tutar
        Application=> server -side object

         
         */
        public ActionResult Index()
        {
            MyUserVM vm = new MyUserVM();

            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Satis");
            }

            if (Request.Cookies["bilgiler"]!=null)// Eğer daha önceden kaydedilmiş bir cookie varsa
            {
                var httpCookie = Request.Cookies["bilgiler"];// Kaydedilmiş cookie'yi oku
                vm.FirstName = httpCookie.Values["username"]; // Kaydedilmiş kullanıcı adını (username) oku ve view modeline ata
                vm.LastName = httpCookie.Values["lastname"];
                vm.Password = httpCookie.Values["password"];
                
            }
            return View(vm);// View modelini kullanarak view'i render et
        }
        [HttpPost]
        public ActionResult HusamettinPost(MyUserVM vm)
        {//todo db ye gidip kullanıcı var mı kontrol et
            Session.Add("giris","giriş yapıldı" + DateTime.Now);
            FormsAuthentication.SetAuthCookie(vm.FirstName, true);

            if (vm.RememberMe) 
            {
                //kullanıcı adı, soyad, age
                HttpCookie cookie = new HttpCookie("bilgiler");
                cookie.Expires = DateTime.Now.AddDays(1);// bir gün geçerli cookie
                cookie.Values.Add("username", vm.FirstName);
                cookie.Values.Add("lastname", vm.LastName);
                cookie.Values.Add("password", vm.Password);
               
                HttpContext.Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index","Satis");// yönlendirmek için RedirectToAction kullandık
        }
        [HttpPost]
        public ActionResult UnutBeni()
        {
            HttpCookie cookie = new HttpCookie("bilgiler");
            cookie.Expires = DateTime.Now.AddDays(-1); // çerezi silmek için geçmiş bir tarih kullanılır
            HttpContext.Response.SetCookie(cookie);//çerezin değeri sıfırlanarak silinir.
            return RedirectToAction("Index");// işlemin tamamlandığı ve kullanıcının ana sayfaya yönlendirildiği belirtilir.
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Acoount");
        }

    }
}