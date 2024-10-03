using System.ComponentModel.DataAnnotations;

namespace MVC_ThomasMore.Data.Entities
{
    public class KlantEntitity: IEntity
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
        public List<BestellingEntity> Bestellingen { get; set; } = new List<BestellingEntity>();
    }
}