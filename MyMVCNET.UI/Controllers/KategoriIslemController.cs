using MyMVCNET.UI.Models.DAL;
using MyMVCNET.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Controllers
{
    public class KategoriIslemController : Controller
    {
        public KategoriIslemController()
        {
        }
        //post-back ?
        // GET: KategoriIslem
        public ActionResult Index()
        {
            return View(new KategoriDAL().KategoriGetir()/*.OrderBy(a=>a.ID)*/);
        }
        //Duzenle

        public ActionResult Duzenle(int? id)
        {
            //http statusCode 
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            //db ye bağlan 5 nolu datayı getir. 
            KategoriVM gelenDataBilgisi = new KategoriDAL().IDBilgisineGoreKategoriBilgileriniGetir(id);
            if (gelenDataBilgisi == null)
            {
                return HttpNotFound();
            }
            return View(gelenDataBilgisi);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Duzenle(KategoriVM vm)
        {
            int eklenenSAtirSayisi = new KategoriDAL().KategoriyiVeriTabanındaDuzenle(vm);
            #region MyRegion
            //return eklenenSAtirSayisi > 0
            //    ? RedirectToAction("Index")
            //    : new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest); 
            #endregion

            if (eklenenSAtirSayisi > 0)
            {
                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }


    }
}