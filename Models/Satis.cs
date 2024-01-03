using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProjesi1.Models
{
    public class Satis
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MusteriId { get; set; }  

        [ValidateNever]
        public int UrunId { get; set; }
        [ForeignKey("UrunId")]

        [ValidateNever]
        public Urun Urun { get; set; }

        public int urunadedi { get; set; }






    }
}
