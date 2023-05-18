using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Controllers
{
    [Authorize]
    public class SatisController : Controller
    {
        // GET: Satis
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.girisYapmisKullanici=User.Identity.Name;
            SatisVM vm = new SatisVM();
            vm.Products = null;
            vm.Shippers = null;
            vm.Customers = null;
            vm.Emplooyes = null;
            return View(vm);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Index(SatisVM vM)
        {
            if (ModelState.IsValid)
            {
                //todo
            }
            return RedirectToAction("Index");
        }
    }
}