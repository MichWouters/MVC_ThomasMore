namespace MVC_ThomasMore.Model
{
    public class Categorie : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DatumToegevoegd { get; set; }

        // Navigation Properties
        public List<Product> Producten { get; set; }
    }
}
