using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Data
{
    public class ProductRepository : IProductRepo
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

        public async Task DeleteItemAsync(Product product)
        {
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

        public async Task<Product> GetProductWithCategory(int id)
        {
            return await _dbContext.Producten
                .Include(x => x.Categorie)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetTopXMostExpensiveProducts(int amount = 3)
        {
            return await _dbContext.Producten
                .Include(x => x.Categorie)
                .OrderByDescending(x => x.Prijs)
                .Take(amount)
                .ToListAsync();
        }

        public async Task UpdateItemAsync(Product item)
        {
            _dbContext.Producten.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}