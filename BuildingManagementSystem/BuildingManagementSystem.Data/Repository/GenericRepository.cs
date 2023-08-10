
using System.Data.Entity;
using System.Linq.Expressions;

namespace BuildingManagementSystem.Data.Repository;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
{
    private readonly ManagementDbContext _dbContext;
    public GenericRepository(ManagementDbContext dbContext)
    {

        _dbContext = dbContext;

    }
    public void Delete(Entity entity)
    {
       _dbContext.Set<Entity>().Remove(entity);
    }

    public void DeleteById(int id)
    {
        var entity = _dbContext.Set<Entity>().Find();
        Delete(entity);
    }

    public List<Entity> GetAll()
    {
        return _dbContext.Set<Entity>().ToList();   
    }

    public IQueryable<Entity> GetAllAsQueryable()
    {
        return _dbContext.Set<Entity>().AsQueryable();
    }

    public List<Entity> GetAllWithInclude(params string[] includes)
    {
        var query = _dbContext.Set<Entity>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => current.Include(inc));
        return query.ToList();
    }

    public Entity GetById(int id)
    {
       var entity = _dbContext.Set<Entity>().Find(id);
        return entity;
    }

    public Entity GetByIdWithInclude(int id, params string[] includes)
    {
        var query = _dbContext.Set<Entity>().AsQueryable();
        query = includes.Aggregate(query, (current, inc)=>current.Include(inc));
        return query.FirstOrDefault(); //bu satır eksik
    }

    public void Insert(Entity entity)
    {
       _dbContext.Set<Entity>().Add(entity);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void Update(Entity entity)
    {
        _dbContext.Set<Entity>().Update(entity);    
    }

    public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression)
    {
        return _dbContext.Set<Entity>().Where(expression).AsQueryable();
    }

    public IEnumerable<Entity> WhereWithInclude(Expression<Func<Entity, bool>> expression, params string[] includes)
    {
        var query = _dbContext.Set<Entity>().AsQueryable();
        query.Where(expression);
        query = includes.Aggregate(query, (current, inc) => current.Include(inc));
        return query.ToList();
    }
}
