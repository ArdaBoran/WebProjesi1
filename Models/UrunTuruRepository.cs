using System.Linq.Expressions;
using WebProjesi1.Utility;

namespace WebProjesi1.Models
{
    public class UrunTuruRepository : Repository<UrunTuru>, IUrunTuruRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public UrunTuruRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(UrunTuru UrunTuru)
        {
            _uygulamaDbContext.Update(UrunTuru);

        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();    
    
        }

    }

}
