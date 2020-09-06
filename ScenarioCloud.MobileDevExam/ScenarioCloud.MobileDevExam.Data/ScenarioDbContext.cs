using ScenarioCloud.MobileDevExam.Business;
using ScenarioCloud.MobileDevExam.Business.Security;
using System.Data.Entity;

namespace ScenarioCloud.MobileDevExam.Data
{
  public class ScenarioDbContext : DbContext, IScenarioDbContext
  {
    public ScenarioDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
    {
      Configuration.LazyLoadingEnabled = false;
      Database.SetInitializer(new ScenarioDbContextInitializer());
    }

    public DbSet<BusinessEntity> BusinessEntities { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Register> Registers { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    public DbSet<User> Users { get; set; }
  }
}
