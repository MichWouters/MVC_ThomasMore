using System.ComponentModel.DataAnnotations;

namespace MVC_ThomasMore.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        [MinLength(3, ErrorMessage = "Naam moet uit minstens 3 tekens bestaan")]
        public string Naam { get; set; }

        [Range(10, 100, ErrorMessage = "Prijs moet tussen 10 en 100 liggen")]
        public double Prijs { get; set; }

        public DateTime DatumToegevoegd { get; set; }

        // Navigation Properties
        public List<Orderlijn> OrderLijnen {  get; set; } = new List<Orderlijn>();

        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
