using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_ThomasMore.Data.Entities;
using MVC_ThomasMore.Data.Repositories;
using MVC_ThomasMore.DTO.Product;
using MVC_ThomasMore.Model;
using MVC_ThomasMore.Services;

namespace MVC_ThomasMore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize] // Gebruiker moet ingelogd zijn
    public class ProductController : ControllerBase
    {
        private IProductRepo _repo;
        private IProductService _service;
        private IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper, IProductRepo repo)
        {
            _service = service;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductDTO[]>> GetProductAsync(int id)
        {
            Product model = await _service.GetProductAsync(id);

            ProductDTO result = _mapper.Map<ProductDTO>(model);

            if (result != null)
                return Ok(result);
            else
                return NotFound();

        }

        [HttpGet]
        [AllowAnonymous] // Deze methode vereist geen login
        public async Task<ActionResult<ProductDTO[]>> GetAllProductsAsync()
        {
            // Haal DB data op
            List<ProductEntity> productEntities = await _repo.GetAllAsync();

            // Giet DB data (Entiteit in een Model)
            List<Product> producten = new List<Product>();

            // Map met Automapper
            producten = _mapper.Map<List<Product>>(productEntities);

            List<ProductDTO> result = new List<ProductDTO>();

            foreach (var product in producten)
            {
                result.Add(new ProductDTO
                {
                    Prijs = product.Prijs,
                    Naam = product.ProductNaam,
                });
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("ProductenMetCategorie")]
        public async Task<ActionResult<ProductDTO[]>> GetAllProductsWithCategoriesAsync()
        {
            List<ProductEntity> entities = await _repo.GetAllProductsWithCategoriesAsync();

            List<Product> models = _mapper.Map<List<Product>>(entities);

            List<ProductDTO> dtos = _mapper.Map<List<ProductDTO>>(models);

            return Ok(dtos);
        }

        //[HttpGet]
        //[Route("TopThree")]
        //public async Task<ActionResult<ProductDTO[]>> GetTopThreeProducts()
        //{
        //    List<Product> producten = await _repo.GetTopXMostExpensiveProducts();
        //    List<ProductDTO> result = new List<ProductDTO>();

        //    foreach (var product in producten)
        //    {
        //        result.Add(new ProductDTO
        //        {
        //            Prijs = product.Prijs,
        //            Naam = product.ProductNaam,
        //            Categorie = product.Categorie.Name,
        //        });
        //    }

        //    return Ok(result);
        //}



        //[HttpPost]
        //public async Task<ActionResult> AddProduct(AddProductDTO dto)
        //{
        //    // Defensive coding
        //    if (ModelState.IsValid)
        //    {
        //        // Map dto naar model
        //        Product product = new Product
        //        {
        //            CategorieId = dto.CategorieId,
        //            DatumToegevoegd = DateTime.Now,
        //            ProductNaam = dto.Naam,
        //            Prijs = dto.Prijs
        //        };

        //        await _repo.AddItemAsync(product);

        //        return CreatedAtAction(nameof(AddProduct), null);
        //    }
        //    else
        //    {
        //        // Data annotaties waren ongeldig
        //        return BadRequest(ModelState);
        //    }
        //}

        //[HttpPut]
        //public async Task<ActionResult> UpdateProduct(int id, UpdateProductDTO updatedProduct) // TODO: DTO
        //{
        //    // Defensive coding
        //    Product product = await _repo.GetItemAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound("Product bestaat niet!");
        //    }

        //    // Mapping
        //    product.ProductNaam = updatedProduct.Naam;
        //    product.Prijs = updatedProduct.Prijs;

        //    await _repo.UpdateItemAsync(product);

        //    return CreatedAtAction(nameof(UpdateProduct), null); // Gebruik nameof voor de naam van een methode of variabele in string formaat te krijgen.
        //}

        //[HttpDelete]
        //public async Task<ActionResult> DeleteProduct(int id)
        //{
        //    // Defensive coding
        //    Product product = await _repo.GetItemAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound("Product bestaat niet!");
        //    }

        //    await _repo.DeleteItemAsync(product);

        //    return Ok("Product is verwijderd");
        //}
    }
}