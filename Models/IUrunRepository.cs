namespace WebProjesi1.Models
{
    public interface IUrunRepository : IRepository<Urun>
    {

        void Guncelle(Urun Urun);
        void Kaydet();
    }
}
