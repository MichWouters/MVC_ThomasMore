namespace MVC_ThomasMore.Model
{
    public class Product : IModel
    {
        public int Id { get; set; }

        public string ProductNaam { get; set; }

        public double Prijs { get; set; }

        public double TotaalPrijs { get; set; }

        public double PrijsInDollar => Math.Round(Prijs * 0.9, 2);

        public double PrijsInPond => Math.Round(Prijs * 1.1, 2);

        public List<Orderlijn> OrderLijnen { get; set; } = new List<Orderlijn>();

        public int CategorieId { get; set; }

        public Categorie Categorie { get; set; }

    }
}