using System.Threading.Tasks;

namespace ScenarioCloud.MobileDevExam.Data
{
  public interface IDataSeeder
  {
    void Seed();
    Task SeedAsync();
  }
}
