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
            List<Product> producten = await _repo.GetAllProductsWithCategoriesAsync();

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

        [HttpGet]
        [Route("ProductenMetCategorie")]
        public async Task<ActionResult<ProductDTO[]>> GetAllProductsWithCategoriesAsync()
        {
            List<Product> producten = await _repo.GetAllAsync();

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

        //[HttpGet]
        //[Route("TopThree")]
        //public ActionResult<ProductDTO[]> GetTopThreeProducts()
        //{
        //    Product[] producten = _dbContext
        //        .Producten
        //        .Include (x => x.Categorie)
        //        .OrderByDescending(x => x.Prijs)
        //        .Take(3)
        //        .ToArray();

        //    List<ProductDTO> result = new List<ProductDTO>();

        //    foreach (var product in producten)
        //    {
        //        result.Add(new ProductDTO
        //        {
        //            Prijs = product.Prijs,
        //            Naam = product.Naam,
        //            Categorie = product.Categorie.Name,
        //        });
        //    }

        //    return Ok(result);
        //}

        //[HttpGet("id")]
        //public ActionResult<Product[]> GetProduct(int id)
        //{
        //    Product product = _dbContext.Producten.Find(id);

        //    ProductDTO result = new ProductDTO()
        //    {
        //        Naam = product.Naam,
        //        Prijs = product.Prijs,
        //        Categorie = product.Categorie.Name,
        //    };

        //    if (result != null)
        //    {
        //        return Ok(product);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }

        //}

        //[HttpPost]
        //public ActionResult AddProduct(AddProductDTO dto)
        //{
        //    // Defensive coding
        //    if (ModelState.IsValid)
        //    {
        //        // Map dto naar model
        //        Product product = new Product
        //        {
        //            CategorieId = dto.CategorieId,
        //            DatumToegevoegd = DateTime.Now,
        //            Naam = dto.Naam,
        //            Prijs = dto.Prijs
        //        };

        //        // Query
        //        _dbContext.Producten.Add(product);

        //        // Execute command
        //        _dbContext.SaveChanges();

        //        return CreatedAtAction(nameof(AddProduct), null);
        //    }
        //    else
        //    {
        //        // Data annotaties waren ongeldig
        //        return BadRequest(ModelState);
        //    }
        //}

        //[HttpPut]
        //public ActionResult UpdateP(int id, Product updatedProduct)
        //{
        //    // Defensive coding
        //    Product product = _dbContext.Producten.Find(id);

        //    if (product == null)
        //    {
        //        return NotFound("Product bestaat niet!");
        //    }

        //    // Mapping
        //    product.Naam = updatedProduct.Naam;
        //    product.Prijs = updatedProduct.Prijs;
        //    product.DatumToegevoegd = updatedProduct.DatumToegevoegd;

        //    _dbContext.Producten.Update(product);
        //    _dbContext.SaveChanges();

        //    return CreatedAtAction(nameof(UpdateP), null); // Gebruik nameof voor de naam van een methode of variabele in string formaat te krijgen.
        //}

        //[HttpDelete]
        //public ActionResult DeleteProduct(int id)
        //{
        //    // Defensive coding
        //    Product product = _dbContext.Producten.Find(id);

        //    if (product == null)
        //    {
        //        return NotFound("Product bestaat niet!");
        //    }

        //    _dbContext.Producten.Remove(product);
        //    _dbContext.SaveChanges();

        //    return Ok("Product is verwijderd");
        //}
    }
}
