namespace MVC_ThomasMore.Model
{
    public class Categorie : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Navigation Properties
        public List<Product> Producten { get; set; }
    }
}