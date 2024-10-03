using MVC_ThomasMore.Data.Entities;

namespace MVC_ThomasMore.Data.Repositories
{
    public interface IProductRepo : IGenericRepo<ProductEntity>
    {
        Task<List<ProductEntity>> GetAllProductsWithCategoriesAsync();

        Task<ProductEntity> GetProductWithCategory(int id);

        Task<List<ProductEntity>> GetTopXMostExpensiveProducts(int amount = 3);
    }
}