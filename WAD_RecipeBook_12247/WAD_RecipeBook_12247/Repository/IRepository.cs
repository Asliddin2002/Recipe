namespace WAD_RecipeBook_12247.Repository
{
    // StudentId 12247

    public interface IRepository <T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(int it);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
