using System.ComponentModel.DataAnnotations;

namespace MVC_ThomasMore.Model
{
    public class Klant : IModel
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string Gemeente { get; set; }

        public string PostCode { get; set; }

        public string Straat { get; set; }

        public int Huisnummer { get; set; }

        public string BankrekeningNummer { get; set; }

        // Navigation Properties
        public List<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();
    }
}