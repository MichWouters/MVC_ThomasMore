namespace MVC_ThomasMore.Model
{
    public class Bestelling
    {
        public int Id { get; set; }

        public int KlantId { get; set; }

        // Navigation Properties
        public Klant Klant { get; set; }

        public List<Orderlijn> Orderlijnen{ get; set; }
    }
}
