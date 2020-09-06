using ScenarioCloud.MobileDevExam.Business;
using ScenarioCloud.MobileDevExam.Data;

namespace ScenarioCloud.MobileDevExam.WebApp.Services.Business
{
  public class RegisterService : DataService<Register>, IRegisterService
  {
    public RegisterService(IScenarioDbContext dbContext) : base(dbContext)
    { }
  }
}