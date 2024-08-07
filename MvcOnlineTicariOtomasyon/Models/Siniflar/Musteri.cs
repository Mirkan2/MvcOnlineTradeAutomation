using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }
        [Required]
        [DisplayName("Müşteri Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string MusteriAdi { get; set; }
        [Required]
        [DisplayName("Müşteri SoyAdı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string MusteriSoyAdi { get; set; }
        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [Column(TypeName = "Varchar")]
        public string Telno { get; set; }

        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string MusteriMail { get; set; }
        public bool Durum { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [Column(TypeName = "Varchar")]
        public string Sifre { get; set; }
        [DisplayName("Müşteri Şehir")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSehir { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}