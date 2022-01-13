using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OduncKitapASPNETMVCWebSolution_BLL.Managers
{
    public class YazarManager
    {
        // GLOBAL ALAN
        OduncKitapDBEntities dbcontext = new OduncKitapDBEntities();

        public List<Yazarlar> TumAktifYazarlariGetir()
        {
            try
            {
                List<Yazarlar> yazarList = new List<Yazarlar>();
                yazarList = dbcontext.Yazarlar.Where(x => !x.SilindiMi).ToList();
                return yazarList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
