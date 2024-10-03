using System.ComponentModel.DataAnnotations;

namespace MVC_ThomasMore.Data.Entities
{
    public class ProductEntity: IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        [MinLength(3)]
        public string Naam { get; set; }

        [Range(10, 100)]
        public double Prijs { get; set; }

        public DateTime DatumToegevoegd { get; set; }

        // Navigation Properties
        public List<OrderLijnEntity> OrderLijnen { get; set; } = new List<OrderLijnEntity>();

        public int CategorieId { get; set; }
        public CategorieEntity Categorie { get; set; }
    }
}