using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OduncKitapASPNETMVCWebSolution_UI.Models
{
    public class KitapViewModel
    {
        public int Id { get; set; }
        public System.DateTime KayitTarihi { get; set; }

        [Required(ErrorMessage = "Kitap adı gereklidir.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Kitap adı 1-50 karakter aralığında olmalıdır.")]

        public string KitapAdi { get; set; }
        public byte TurId { get; set; }
        public int YazarId { get; set; }

        [Required(ErrorMessage = "Sayfa sayısı gereklidir.")]
        public int SayfaSayisi { get; set; }

        [Required(ErrorMessage = "Stok sayısı gereklidir.")]
        public int StokAdeti { get; set; }
        public bool SilindiMi { get; set; }
        public string ResimLink { get; set; }
        public HttpPostedFileBase Resim { get; set; }
    }
}