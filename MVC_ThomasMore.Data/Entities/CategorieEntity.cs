namespace MVC_ThomasMore.Data.Entities
{
    public class CategorieEntity: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DatumToegevoegd { get; set; }

        // Navigation Properties
        public List<ProductEntity> Producten { get; set; }
    }
}