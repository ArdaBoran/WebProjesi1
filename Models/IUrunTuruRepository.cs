namespace WebProjesi1.Models
{
    public interface IUrunTuruRepository : IRepository<UrunTuru>
    {

        void Guncelle(UrunTuru UrunTuru);
        void Kaydet();
    }
}
