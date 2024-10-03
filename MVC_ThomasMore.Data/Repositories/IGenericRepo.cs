using MVC_ThomasMore.Data.Entities;

namespace MVC_ThomasMore.Data.Repositories
{
    public interface IGenericRepo<T> where T : IEntity
    {
        Task AddItemAsync(T item);

        Task UpdateItemAsync(T item);

        Task DeleteItemAsync(T item);

        Task<T> GetItemAsync(int id);

        Task<List<T>> GetAllAsync();
    }
}