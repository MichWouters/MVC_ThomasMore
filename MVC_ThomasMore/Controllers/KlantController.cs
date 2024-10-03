using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.DTO.Klant;
using MVC_ThomasMore.DTO.Product;
using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlantController : ControllerBase
    {
        private WebApiDataContext _dbContext;

        public KlantController(WebApiDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<KlantDTO> GetKlant(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id mag niet kleiner zijn dan 1");
            }

            Klant klant = _dbContext
                .Klanten
                .Include(x => x.Bestellingen)
                .ThenInclude(y => y.Orderlijnen)
                .ThenInclude(z => z.Product)
                .FirstOrDefault();

            List<Product> products = _dbContext.Producten.ToList();
            List<ProductDTO> productDtos = new List<ProductDTO>();

            foreach (Product product in products)
            {
                productDtos.Add(new ProductDTO
                {
                    Naam = product.Naam,
                    Prijs = product.Prijs
                });
            }

            KlantDTO dto = new KlantDTO()
            {
                KlantNaam = $"{klant.Naam} {klant.Voornaam}",
                Products = productDtos,
            };

            if (klant == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dto);
            }
        }
    }
}