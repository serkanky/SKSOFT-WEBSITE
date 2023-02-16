using GSF.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Sksoft.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mail = Sksoft.Entity.Mail;

namespace Sksoft.DataAccess
{
    public class SksContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEVELOPER\\SQLEXPRESS;Database=SkSoftKatmanli; integrated security=true; TrustServerCertificate=True;");
        }
        public DbSet<Ayarlar> Ayarlar { get; set; }
        public DbSet<Blog>? Blog { get; set; }
        public DbSet<Hakkimizda>? Hakkimizda { get; set; }
        public DbSet<Iletisim>? Iletisim { get; set; }
        public DbSet<Kullanici>? Kullanici { get; set; }
        public DbSet<Slider>? Slider { get; set; }
        public DbSet<Urunlerimiz>? Urunlerimiz { get; set; }
        public DbSet<Mail>? Mail { get; set; }
    }
}
