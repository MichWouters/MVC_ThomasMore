using MVC_ThomasMore.DTO.Product;

namespace MVC_ThomasMore.DTO.Klant
{
    public class KlantDTO
    {
        public string KlantNaam {  get; set; }

        public List<ProductDTO> Products { get; set; }
    }
}
