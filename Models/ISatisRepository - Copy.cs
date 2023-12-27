namespace WebProjesi1.Models
{
    public interface ISatisRepository : IRepository<Satis>
    {

        void Guncelle(Satis Satis);
        void Kaydet();
    }
}
