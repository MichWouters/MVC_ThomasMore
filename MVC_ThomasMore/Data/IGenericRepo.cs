using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Data
{
    public interface IGenericRepo<T> where T: IModel
    {
        Task AddItemAsync(T item);

        Task UpdateItemAsync(int id, T item);

        Task DeleteItemAsync(int id);

        Task<T> GetItemAsync(int id);

        Task<List<T>> GetAllAsync();

        
    }
}
