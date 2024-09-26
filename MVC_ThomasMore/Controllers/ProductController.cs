using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.Data;
using MVC_ThomasMore.DTO.Product;
using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        // Dependencies zijn ingredienten -> Bovenaan oplijsten
        private WebApiDataContext _dbContext;

        public ProductController(WebApiDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<Product[]> GetAllProducts(string naam)
        {
            Product[] producten = _dbContext
                .Producten
                .Where(x => x.Naam.Contains(naam))
                .ToArray();

            return Ok(producten);
        }

        [HttpGet]
        [Route("ProductenMetCategorie")]
        public ActionResult<ProductDTO[]> GetAllProductsWithCategories()
        {
            Product[] products = _dbContext.Producten
                .Include(x => x.Categorie)
                .ToArray();

            List<ProductDTO> dtos = new List<ProductDTO>();

            foreach (Product product in products)
            {
                dtos.Add(new ProductDTO
                {
                    Naam = product.Naam,
                    Prijs = product.Prijs,
                    Categorie = product.Categorie.Name
                });
            }

            return Ok(dtos);
        }

        [HttpGet]
        [Route("TopThree")]
        public ActionResult<Product[]> GetTopThreeProducts()
        {
            Product[] producten = _dbContext
                .Producten
                .OrderByDescending(x => x.Prijs)
                .Take(3)
                .ToArray();

            return Ok(producten);
        }

        [HttpGet("id")]
        public ActionResult<Product[]> GetProduct(int id)
        {
            Product product = _dbContext.Producten.Find(id);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult AddProduct(AddProductDTO dto)
        {
            // Defensive coding
            if (ModelState.IsValid)
            {
                // Map dto naar model
                Product product = new Product
                {
                    CategorieId = dto.CategorieId,
                    DatumToegevoegd = DateTime.Now,
                    Naam = dto.Naam,
                    Prijs = dto.Prijs
                };

                // Query
                _dbContext.Producten.Add(product);

                // Execute command
                _dbContext.SaveChanges();

                return CreatedAtAction(nameof(AddProduct), null);
            }
            else
            {
                // Data annotaties waren ongeldig
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public ActionResult UpdateP(int id, Product updatedProduct)
        {
            // Defensive coding
            Product product = _dbContext.Producten.Find(id);

            if (product == null)
            {
                return NotFound("Product bestaat niet!");
            }

            // Mapping
            product.Naam = updatedProduct.Naam;
            product.Prijs = updatedProduct.Prijs;
            product.DatumToegevoegd = updatedProduct.DatumToegevoegd;

            _dbContext.Producten.Update(product);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(UpdateP), null); // Gebruik nameof voor de naam van een methode of variabele in string formaat te krijgen.
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            // Defensive coding
            Product product = _dbContext.Producten.Find(id);

            if (product == null)
            {
                return NotFound("Product bestaat niet!");
            }

            _dbContext.Producten.Remove(product);
            _dbContext.SaveChanges();

            return Ok("Product is verwijderd");
        }
    }
}
