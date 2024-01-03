using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProjesi1.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? UrunAdi { get; set; }

        public string? Tanim { get; set; }

        [Required]
        public string? Barkod { get; set; }

        [Required]
        [Range(10,5000)]//Fiyat Aralığı diyebiliriz.
        public  double  Fiyat { get; set; }

        [ValidateNever]
        public int UrunTuruId { get; set; }
        [ForeignKey("UrunTuruId")]

        [ValidateNever]
        public UrunTuru UrunTuru { get; set;}

        [ValidateNever]
        public string ResimUrl { get; set; }

        public int StokMiktari { get; set; }



    }
}
