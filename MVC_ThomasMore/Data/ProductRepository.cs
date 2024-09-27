using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Data
{
    public class ProductRepository :IProductRepo
    {
        private WebApiDataContext _dbContext;

        public ProductRepository(WebApiDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddItemAsync(Product item)
        {
            await _dbContext.Producten.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(int id, Product item)
        {
            _dbContext.Producten.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            Product product = new Product { Id = id };

            _dbContext.Producten.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Producten.ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsWithCategoriesAsync()
        {
            return await _dbContext.Producten
                .Include(x => x.Categorie)
                .ToListAsync();
        }

        public async Task<Product> GetItemAsync(int id)
        {
            return await _dbContext.Producten.FindAsync(id);
        }
    }
}
