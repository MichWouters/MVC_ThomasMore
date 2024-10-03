namespace MVC_ThomasMore.Data.Entities
{
    public class BestellingEntity: IEntity
    {
        public int Id { get; set; }

        public int KlantId { get; set; }

        // Navigation Properties
        public KlantEntitity Klant { get; set; }

        public List<OrderLijnEntity> Orderlijnen { get; set; }
    }
}