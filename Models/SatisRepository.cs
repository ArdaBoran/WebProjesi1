using System.Linq.Expressions;
using WebProjesi1.Utility;

namespace WebProjesi1.Models
{
    public class SatisRepository : Repository<Satis>, ISatisRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public SatisRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Satis Satis)
        {
            _uygulamaDbContext.Update(Satis);

        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();    
    
        }

    }

}
