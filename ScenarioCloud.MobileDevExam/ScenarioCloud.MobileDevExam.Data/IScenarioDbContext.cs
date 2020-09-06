using ScenarioCloud.MobileDevExam.Business;
using ScenarioCloud.MobileDevExam.Business.Security;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace ScenarioCloud.MobileDevExam.Data
{
  public interface IScenarioDbContext : IDisposable
  {
    Database Database { get; }
    DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    int SaveChanges();
    Task<int> SaveChangesAsync();

    DbSet<BusinessEntity> BusinessEntities { get; set; }
    DbSet<Document> Documents { get; set; }
    DbSet<Project> Projects { get; set; }
    DbSet<Register> Registers { get; set; }
    DbSet<UserToken> UserTokens { get; set; }
    DbSet<User> Users { get; set; }
  }
}
