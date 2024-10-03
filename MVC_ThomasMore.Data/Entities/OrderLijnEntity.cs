namespace MVC_ThomasMore.Data.Entities
{
    public class OrderLijnEntity: IEntity
    {
        // Dit is een associatie tabel
        // Bevat 2 Foreign keys naar andere tabellen -> Eg: 2 Een op veel maakt een veel op veel
        public int Id { get; set; } // In principe overbodig: Combinatie van Foreign keys (composite) is al uniek

        public int BestellingId { get; set; }

        public int ProductID { get; set; }

        public int Aantal { get; set; }

        // Navigation Properties
        public BestellingEntity Bestelling { get; set; }

        public ProductEntity Product { get; set; }
    }
}