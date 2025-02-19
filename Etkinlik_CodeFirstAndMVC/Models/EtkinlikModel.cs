using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Etkinlik_CodeFirstAndMVC.Models
{
    public partial class EtkinlikModel : DbContext
    {
        public EtkinlikModel()
            : base("name=EtkinlikModel")
        {
        }

        public DbSet<Etkinlik> Etkinlikler { get; set; }
        public DbSet<Soru> Sorular { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
