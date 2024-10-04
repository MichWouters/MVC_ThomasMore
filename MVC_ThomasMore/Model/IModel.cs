namespace MVC_ThomasMore.Model
{
    // Gedeelde interface om ervoor te zorgen dat elk model een ID moet hebben
    public interface IModel
    {
        public int Id { get; set; }
    }
}