using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Data
{
    public interface IGenericRepo<T> where T: IModel
    {
        Task AddItemAsync(T item);

        Task UpdateItemAsync(T item);

        Task DeleteItemAsync(T item);

        Task<T> GetItemAsync(int id);

        Task<List<T>> GetAllAsync();

        
    }
}
