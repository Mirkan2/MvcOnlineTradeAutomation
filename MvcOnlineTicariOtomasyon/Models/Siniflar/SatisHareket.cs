using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int Satisid { get; set; }
        //public DateTime Tarih { get; set; }
        //public int Adet { get; set; }
        //public decimal Fiyat { get; set; }
        //public decimal ToplamTutar { get; set; }

        //public int Urunid { get; set; }
        //public int Cariid { get; set; }
        //public int Personelid { get; set; }

        //public virtual Urun Urun { get; set; }
        //public virtual Musteri Cariler { get; set; }
        //public virtual Personel Personel { get; set; }
        [Required]
        [DisplayName("Satış Tarihi")]
        public DateTime Tarih { get; set; }
        [Required]
        public int Adet { get; set; }
        [Required]
        [DisplayName("Satış Fiyatı")]
        public decimal Fiyat { get; set; }
        [Required]
        [DisplayName("Toplam Tutar")]
        public decimal Tutar { get; set; }
        public int Urunid { get; set; }
        public int Musteriid { get; set; }
        public int Personelid { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Musteri Musteri { get; set; }
        public virtual Personel Personel { get; set; }
    }
}