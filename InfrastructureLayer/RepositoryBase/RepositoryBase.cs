using InfrastructureLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace InfrastructureLayer;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public RepositoryBase(RepositoryContext context) => Context = context;

    protected RepositoryContext Context { get; init; }

    public IQueryable<T> FindAll() => this.Context.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        => this.Context.Set<T>().Where(expression).AsNoTracking();

    public void Create(T entity) => this.Context.Set<T>().Add(entity);

    public void CreateRange(List<T> entity) => this.Context.Set<T>().AddRange(entity);

    public void Update(T entity) => this.Context.Set<T>().Update(entity);

    public void UpdateRange(List<T> entity) => this.Context.Set<T>().UpdateRange(entity);

    public void Delete(T entity) => this.Context.Set<T>().Remove(entity);

    public void DeleteRange(List<T> entity) => this.Context.Set<T>().RemoveRange(entity);
}

