using System.ComponentModel.DataAnnotations;

namespace MVC_ThomasMore.Data.Entities
{
    /* Een entiteit is een 1-1 code weergave van een database tabel
     * Deze mag dus enkel in speciale gevallen aangepast worden,
     * anders is een DB update nodig
     */

    public class ProductEntity : IEntity
    {
        public int Id { get; set; }

        // We gebruiken Data Annotations om de tabel structuur op te stellen
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