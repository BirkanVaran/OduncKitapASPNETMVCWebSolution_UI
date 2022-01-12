using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OduncKitapASPNETMVCWebSolution_BLL;
using OduncKitapASPNETMVCWebSolution_BLL.Managers;

namespace OduncKitapASPNETMVCWebSolution_UI.Controllers
{
    public class KitapController : Controller
    {
        // GLOBAL ALAN
        KitapManager myKitapManager = new KitapManager();

        // GET: Kitap
        public ActionResult Index()
        {
            try
            {
                List<Kitaplar> kitaplist = myKitapManager.TumAktifKitaplariGetir();
                ViewBag.KitapListCount = 0;
                if (kitaplist.Count > 0)
                {
                    ViewBag.KitapListCount = kitaplist.Count;
                }
                return View(kitaplist);
            }
            catch (Exception ex)
            {

                ViewBag.HataMesaji = "Beklenmedik bir hata oluştu! - " + ex.Message;
                return View();
            }
        }
    }
}