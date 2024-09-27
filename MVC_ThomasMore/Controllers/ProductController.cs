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
        private IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDTO[]>> GetAllProductsAsync()
        {
            List<Product> producten = await _repo.GetAllAsync();

            List<ProductDTO> result = new List<ProductDTO>();

            foreach (var product in producten)
            {
                result.Add(new ProductDTO
                {
                    Prijs = product.Prijs,
                    Naam = product.Naam,
                });
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("ProductenMetCategorie")]
        public async Task<ActionResult<ProductDTO[]>> GetAllProductsWithCategoriesAsync()
        {
            List<Product> producten = await _repo.GetAllProductsWithCategoriesAsync();

            List<ProductDTO> dtos = new List<ProductDTO>();

            foreach (Product product in producten)
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
        public async Task<ActionResult<ProductDTO[]>> GetTopThreeProducts()
        {
            List<Product> producten = await _repo.GetTopXMostExpensiveProducts();
            List<ProductDTO> result = new List<ProductDTO>();

            foreach (var product in producten)
            {
                result.Add(new ProductDTO
                {
                    Prijs = product.Prijs,
                    Naam = product.Naam,
                    Categorie = product.Categorie.Name,
                });
            }

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductDTO[]>> GetProductAsync(int id)
        {
            Product product = await _repo.GetProductWithCategory(id);

            ProductDTO result = new ProductDTO()
            {
                Naam = product.Naam,
                Prijs = product.Prijs,
                Categorie = product.Categorie.Name,
            };

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(AddProductDTO dto)
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

                await _repo.AddItemAsync(product);

                return CreatedAtAction(nameof(AddProduct), null);
            }
            else
            {
                // Data annotaties waren ongeldig
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProductDTO updatedProduct) // TODO: DTO
        {
            // Defensive coding
            Product product = await _repo.GetItemAsync(id);

            if (product == null)
            {
                return NotFound("Product bestaat niet!");
            }

            // Mapping
            product.Naam = updatedProduct.Naam;
            product.Prijs = updatedProduct.Prijs;

            await _repo.UpdateItemAsync(product);

            return CreatedAtAction(nameof(UpdateProduct), null); // Gebruik nameof voor de naam van een methode of variabele in string formaat te krijgen.
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            // Defensive coding
            Product product = await _repo.GetItemAsync(id);

            if (product == null)
            {
                return NotFound("Product bestaat niet!");
            }

            await _repo.DeleteItemAsync(product);

            return Ok("Product is verwijderd");
        }
    }
}
