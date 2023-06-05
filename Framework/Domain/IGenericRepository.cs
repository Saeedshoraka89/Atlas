namespace Framework.Domain;

public interface IGenericRepository<in TKey, T> where T : class
{
    ValueTask<ICollection<T>> GetAllAsync();
    ValueTask<T> GetById(TKey id);
    ValueTask CreateAsync(T entity);
    ValueTask<bool> CheckExistAsync(Expression<Func<T, bool>> expression);
    ValueTask SaveAsync();
}