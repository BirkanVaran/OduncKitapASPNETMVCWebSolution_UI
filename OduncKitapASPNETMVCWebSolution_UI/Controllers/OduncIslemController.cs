﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OduncKitapASPNETMVCWebSolution_BLL.Managers;
using OduncKitapASPNETMVCWebSolution_UI.Models;
using OduncKitapASPNETMVCWebSolution_BLL;

namespace OduncKitapASPNETMVCWebSolution_UI.Controllers
{
    public class OduncIslemController : Controller
    {
        // GLOBAL ALAN
        KitapManager myKitapManager = new KitapManager();
        UyeManager myUyeManager = new UyeManager();
        OduncIslemManager myOduncIslemManager = new OduncIslemManager();
        // GET: OduncIslem
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> kitapListesi = new List<SelectListItem>();
            myKitapManager.TumAktifKitaplariGetir().ForEach(
                x =>
                kitapListesi.Add(new SelectListItem()
                {
                    Text = x.KitapAdi,
                    Value = x.Id.ToString()
                }));
            ViewBag.KitapListesi = kitapListesi;

            List<SelectListItem> uyeListesi = new List<SelectListItem>();
            myUyeManager.TumAktifUyeleriGetir().ForEach(
                x =>
                uyeListesi.Add(new SelectListItem()
                {
                    Text = x.UyeAdi + " " + x.UyeSoyadi,
                    Value = x.Id.ToString()
                }));
            ViewBag.UyeListesi = uyeListesi;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(OduncIslemViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Geçerli veri girişi yapınız.");
                    return View(model);
                }

                OduncIslemler yeniOduncIslem = new OduncIslemler()
                {
                    KayitTarihi = DateTime.Now,
                    KitapId = model.KitapId,
                    UyeId = model.UyeId,
                    OduncAlinmaTarihi = model.OduncAlinmaTarihi,
                    // Personel ID=1 olarak manuel verdik. Gelecek hafta öğrendiklerimizle revize edilebilir.
                    PersonelId = 1
                };

                yeniOduncIslem.OduncBitisTarihi = model.OduncAlinmaTarihi.AddDays(15);
                yeniOduncIslem.TeslimEttiMi = false;
                // BLL kayıt etsin
                if (myOduncIslemManager.OduncIslemEkle(yeniOduncIslem))
                {
                    return RedirectToAction("Index", "OduncIslem");
                }
                else
                {
                    ModelState.AddModelError("", "Ödünç verme işleminde beklenmedik bir hata oluştur. İşleminizi tekrar deneyiniz.");
                    return View(model);
                }
                
            }
            catch (Exception ex)
            {

                return View(model);
            }
        } 

    }
}