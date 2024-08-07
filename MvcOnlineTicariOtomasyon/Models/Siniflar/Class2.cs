using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Class2
    {
        [Key]
        public int id { get; set; }
        public string deneme { get; set; }
    }
}