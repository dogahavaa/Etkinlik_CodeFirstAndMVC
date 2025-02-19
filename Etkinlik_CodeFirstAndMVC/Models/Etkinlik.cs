using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Etkinlik_CodeFirstAndMVC.Models
{
    public class Etkinlik
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Etkinlik adı girilmelidir!")]
        [StringLength(maximumLength:150, ErrorMessage = "Etkinlik adı 150 karakteri geçemez.")]
        public string Isim { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Tarih seçilmelidir!")]
        public DateTime Tarih { get; set; }
        public string Resim { get; set; }
        public bool Durum { get; set; }

        public virtual ICollection<Soru> Soru { get; set; }
    }
}