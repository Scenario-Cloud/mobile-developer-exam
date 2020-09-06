using ScenarioCloud.MobileDevExam.Business;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ScenarioCloud.MobileDevExam.Data
{
  public class Seeder<T> : ISeeder<T> where T : class, IEntity
  {
    private readonly IScenarioDbContext context;

    public Seeder(IScenarioDbContext dbContext)
    {
      context = dbContext;
    }
    public Seeder(IScenarioDbContext dbContext, IEnumerable<T> defaultItems) : this(dbContext)
    {
      DefaultItems = defaultItems;
    }

    public IEnumerable<T> DefaultItems { get; set; }

    public virtual void Seed()
    {
      var dataExists = context.Set<T>().Any();
      if (!dataExists &&
          (DefaultItems != null &&
           DefaultItems.Any()))
      {
        context.Set<T>().AddRange(DefaultItems);
        context.SaveChanges();
      }
    }

    public virtual async Task SeedAsync()
    {
      var dataExists =  await context.Set<T>().AnyAsync();
      if (!dataExists &&
          (DefaultItems != null &&
           DefaultItems.Any()))
      {
        context.Set<T>().AddRange(DefaultItems);
        await context.SaveChangesAsync();
      }
    }
  }
}
