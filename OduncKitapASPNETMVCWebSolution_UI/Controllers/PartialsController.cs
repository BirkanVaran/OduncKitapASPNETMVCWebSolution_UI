using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OduncKitapASPNETMVCWebSolution_BLL.Managers;


namespace OduncKitapASPNETMVCWebSolution_UI.Controllers
{
    public class PartialsController : Controller
    {
        // Partiallar kısmi görünüm anlamına gelmektedir.

        // Tüm Partial'ları tek bir yerden yönetmek amacıyla PartailsController oluşturduk.

        // İsterseniz mevcutta var olan controllerlarınız içinde de partial oluşturabilirsiniz.


        //GLOBAL ALAN
        KitapManager myKitapManager = new KitapManager();

        public PartialViewResult MenuPartialResult()
        {
            int toplamKitapSayisi = myKitapManager.TumAktifKitaplariGetir().Count;
            TempData["ToplamKitapSayisi"] = toplamKitapSayisi;

            return PartialView("_PartialMenu");
        }
    }
}