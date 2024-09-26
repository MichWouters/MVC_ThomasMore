using System.ComponentModel.DataAnnotations;

namespace MVC_ThomasMore.Model
{
    public class Klant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naam { get; set; }

        [MaxLength(50)]
        public string Voornaam { get; set; }

        public string Gemeente { get; set; }

        [MaxLength(6)]
        public string PostCode { get; set; }

        public string Straat { get; set; }

        public int Huisnummer { get; set; }

        public string BankrekeningNummer { get; set; }

        // Navigation Properties
        public List<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();
    }
}
