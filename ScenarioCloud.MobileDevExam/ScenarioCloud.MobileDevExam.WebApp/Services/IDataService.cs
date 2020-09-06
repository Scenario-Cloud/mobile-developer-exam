using ScenarioCloud.MobileDevExam.Business;
using ScenarioCloud.MobileDevExam.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScenarioCloud.MobileDevExam.WebApp.Services
{
  public interface IDataService<T> where T : class, IEntity
  {
    IScenarioDbContext DbContext { get; }
    IEnumerable<T> Get(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression);
    T Get(int id);
    Task<T> GetAsync(int id);
    T Save(T item);
    Task<T> SaveAsync(T item);
    IEnumerable<T> Save(IEnumerable<T> items);
    Task<IEnumerable<T>> SaveAsync(IEnumerable<T> items);
    void Remove(T item);
    void Remove(int id);
    void Remove(IEnumerable<T> items);
    Task RemoveAsync(T item);
    Task RemoveAsync(int id);
    Task RemoveAsync(IEnumerable<T> items);
  }
}
