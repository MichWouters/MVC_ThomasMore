using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Services
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(int id);
    }
}