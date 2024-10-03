namespace MVC_ThomasMore.Model
{
    public class Job : IModel
    {
        public int Id { get; set; }

        public string Omschrijving { get; set; }

        public string Locatie { get; set; }

        public DateTime StartDatum { get; set; }

        public DateTime EindDatum { get; set; }

        public bool IsWerkschoenen { get; set; }

        public bool IsKleding { get; set; }

        public bool IsBadge { get; set; }

        public int AantalPlaatsen { get; set; }
    }
}