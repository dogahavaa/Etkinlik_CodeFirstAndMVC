using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Etkinlik_CodeFirstAndMVC.Models
{
    public class Soru
    {
        public int ID { get; set; }
        public int EtkinlikID { get; set; }
        [ForeignKey("EtkinlikID")]
        public virtual Etkinlik Etkinlik { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string Isim { get; set; }
        public string Metin { get; set; }

    }
}