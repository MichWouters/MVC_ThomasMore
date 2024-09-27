using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Data
{
    public interface IProductRepo: IGenericRepo<Product>
    {
        Task<List<Product>> GetAllProductsWithCategoriesAsync();
    }
}
