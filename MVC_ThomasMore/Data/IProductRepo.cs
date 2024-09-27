using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Data
{
    public interface IProductRepo: IGenericRepo<Product>
    {
        Task<List<Product>> GetAllProductsWithCategoriesAsync();
        Task<Product> GetProductWithCategory(int id);
        Task<List<Product>> GetTopXMostExpensiveProducts(int amount = 3);
    }
}
