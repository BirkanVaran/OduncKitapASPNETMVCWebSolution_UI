using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OduncKitapASPNETMVCWebSolution_BLL;
using OduncKitapASPNETMVCWebSolution_BLL.Managers;

namespace OduncKitapASPNETMVCWebSolution_UI.Controllers
{
    public class TurController : Controller
    {
        // GLOBAL ALAN
        TurManager myTurManager = new TurManager();
        // GET: Tur
        public ActionResult Index()
        {
            // Tüm Türler gelecek
            try
            {
                List<Turler> turList = myTurManager.AktifTumTurleriGetir();
                ViewBag.TurListCount = 0;
                if (turList.Count>0)
                {
                    ViewBag.TurListCount = turList.Count;
                }
                return View(turList);
            }
            catch (Exception)
            {
            }
            return View();
        }


    }
}