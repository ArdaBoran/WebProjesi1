

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProjesi1.Models;


//veritabanında entity Framework olusturması icin ilgili model sınıflarımızı buraya eklemeliyiz
namespace WebProjesi1.Utility
{
    public class UygulamaDbContext : IdentityDbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }

        public DbSet<UrunTuru> UrunTurleri { get; set; }
        public DbSet<Urun> Urunlar { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    }
}