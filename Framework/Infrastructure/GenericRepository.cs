namespace Framework.Infrastructure;

public class GenericRepository<TKey, T> : IGenericRepository<TKey, T> where T : class
{
    private readonly DbContext _context;

    public GenericRepository(DbContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async ValueTask<T> GetById(TKey id)
    {
        return (await _context.Set<T>().FindAsync(id))!;
    }

    public async ValueTask CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public async ValueTask<bool> CheckExistAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AnyAsync(expression);
    }

    public async ValueTask SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}