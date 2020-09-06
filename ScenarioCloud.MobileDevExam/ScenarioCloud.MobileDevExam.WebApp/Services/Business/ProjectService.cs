using ScenarioCloud.MobileDevExam.Business;
using ScenarioCloud.MobileDevExam.Data;

namespace ScenarioCloud.MobileDevExam.WebApp.Services.Business
{
  public class ProjectService : DataService<Project>, IProjectService
  {
    public ProjectService(IScenarioDbContext dbContext) : base(dbContext)
    { }
  }
}