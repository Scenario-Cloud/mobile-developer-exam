using ScenarioCloud.MobileDevExam.Business;
using ScenarioCloud.MobileDevExam.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScenarioCloud.MobileDevExam.WebApp.Services
{
  public class DataService<T> : IDataService<T> where T : class, IEntity
  {
    public DataService(IScenarioDbContext dbContext)
    {
      DbContext = dbContext;
    }

    public IScenarioDbContext DbContext { get; }

    public virtual IEnumerable<T> Get(Expression<Func<T, bool>> expression)
    {
      return DbContext.Set<T>().Where(expression).ToList();
    }

    public virtual T Get(int id)
    {
      return DbContext.Set<T>().Find(id);
    }

    public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
    {
      return await DbContext.Set<T>().Where(expression).ToListAsync();
    }

    public virtual async Task<T> GetAsync(int id)
    {
      return await DbContext.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T item)
    {
      DbContext.Set<T>().Remove(item);
      DbContext.SaveChanges();
    }

    public virtual void Remove(int id)
    {
      var item = DbContext.Set<T>().Find(id);
      if (item != null)
      {
        DbContext.Set<T>().Remove(item);
        DbContext.SaveChanges();
      }
    }

    public virtual void Remove(IEnumerable<T> items)
    {
      DbContext.Set<T>().RemoveRange(items);
      DbContext.SaveChanges();
    }

    public virtual async Task RemoveAsync(T item)
    {
      DbContext.Set<T>().Remove(item);
      await DbContext.SaveChangesAsync();
    }

    public virtual async Task RemoveAsync(int id)
    {
      var item = await DbContext.Set<T>().FindAsync(id);
      if (item != null)
      {
        DbContext.Set<T>().Remove(item);
        await DbContext.SaveChangesAsync();
      }
    }

    public virtual async Task RemoveAsync(IEnumerable<T> items)
    {
      DbContext.Set<T>().RemoveRange(items);
      await DbContext.SaveChangesAsync();
    }

    public virtual T Save(T item)
    {
      var existing = DbContext.Set<T>().Find(item.Id);
      if (existing == null)
        existing = DbContext.Set<T>().Add(item);
      else
        DbContext.Entry(existing).CurrentValues.SetValues(item);

      DbContext.SaveChanges();

      return existing;
    }

    public virtual IEnumerable<T> Save(IEnumerable<T> items)
    {
      var persistedItems = new List<T>();

      foreach (var item in items)
          persistedItems.Add(Save(item));

      return persistedItems;
    }

    public virtual async Task<T> SaveAsync(T item)
    {
      var existing = await DbContext.Set<T>().FindAsync(item.Id);
      if (existing == null)
        existing = DbContext.Set<T>().Add(item);
      else
        DbContext.Entry(existing).CurrentValues.SetValues(item);

      await DbContext.SaveChangesAsync();
      return existing;
    }

    public virtual async Task<IEnumerable<T>> SaveAsync(IEnumerable<T> items)
    {
      var persistedItems = new List<T>();

      foreach (var item in items)
      {
        var persistedItem = await SaveAsync(item);
        persistedItems.Add(persistedItem);
      }

      return persistedItems;
    }
  }
}