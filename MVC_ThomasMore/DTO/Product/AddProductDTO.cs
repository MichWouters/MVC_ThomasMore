using System.ComponentModel.DataAnnotations;

namespace MVC_ThomasMore.DTO.Product
{
    public class AddProductDTO
    {
        public int CategorieId { get; set; }

        [Range(0, 100)]
        public double Prijs { get; set; }

        [MaxLength(100)]
        public string Naam { get; set; }
    }
}