using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProjesi1.Models
{
    public class UrunTuru
    {


        [Key] //Primary Key
        public int Id { get; set; }


        [Required(ErrorMessage ="Urun Türü Adı Boş Bırakılamaz!.")]//not null anlamına gelir 
        [MaxLength(25)] //en fazla 25 karakter girilebilir 
        [DisplayName("Urun Türü Adı")]//label kısmı için bu gözükecek eklemedeki 
        public string? Ad { get; set; }



    }
}
