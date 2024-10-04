using Microsoft.EntityFrameworkCore;
using MVC_ThomasMore.Data.Entities;

namespace MVC_ThomasMore.Data.Repositories
{
    // Een repository wordt gebruikt om communicatie met de DB te verrichten
    // We gebruiken enkel Entities (Data layer) om data op te halen en weg te schrijven
    public class ProductRepository : IProductRepo
    {
        private WebApiDataContext _dbContext;

        public ProductRepository(WebApiDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddItemAsync(ProductEntity item)
        {
            await _dbContext.Producten.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(ProductEntity product)
        {
            _dbContext.Producten.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _dbContext.Producten.ToListAsync();
        }

        public async Task<List<ProductEntity>> GetAllProductsWithCategoriesAsync()
        {
            return await _dbContext.Producten
                .Include(x => x.Categorie)
                .ToListAsync();
        }

        public async Task<ProductEntity> GetItemAsync(int id)
        {
            return await _dbContext.Producten.FindAsync(id);
        }

        public async Task<ProductEntity> GetProductWithCategory(int id)
        {
            return await _dbContext.Producten
                .Include(x => x.Categorie)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ProductEntity>> GetTopXMostExpensiveProducts(int amount = 3)
        {
            return await _dbContext.Producten
                .Include(x => x.Categorie)
                .OrderByDescending(x => x.Prijs)
                .Take(amount)
                .ToListAsync();
        }

        public async Task UpdateItemAsync(ProductEntity item)
        {
            _dbContext.Producten.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}