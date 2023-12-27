using System.Linq.Expressions;
using WebProjesi1.Utility;

namespace WebProjesi1.Models
{
    public class UrunRepository : Repository<Urun>, IUrunRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public UrunRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Urun Urun)
        {
            _uygulamaDbContext.Update(Urun);

        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();    
    
        }

    }

}
