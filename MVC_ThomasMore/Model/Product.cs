using System.ComponentModel.DataAnnotations;

namespace MVC_ThomasMore.Model
{
    public class Product : IModel
    {
        public int Id { get; set; }

        public string ProductNaam { get; set; }

        public double Prijs { get; set; }

        public double PrijsInDollar => Prijs * 0.9;

        public double PrijsInPond => Prijs * 1.1;

        public List<Orderlijn> OrderLijnen { get; set; } = new List<Orderlijn>();

        public int CategorieId { get; set; }

        public Categorie Categorie { get; set; }

    }
}