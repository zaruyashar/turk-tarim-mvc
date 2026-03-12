using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Address
    {
        public int AddressID { get; set; }

        [Display(Name = "Açık Adres")]
        public string? Description1 { get; set; }
       
        [Display(Name = "Şehir/Ülke")]
        public string? Description2 { get; set; }
       
        [Display(Name = "E-posta Adresi")]
        public string? Description3 { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string? Description4 { get; set; }
        public string? MapInfo { get; set; }
    }
}
