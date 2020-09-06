using ScenarioCloud.MobileDevExam.Business.Security;
using ScenarioCloud.MobileDevExam.WebApp.Models.Security;
using System.Threading.Tasks;

namespace ScenarioCloud.MobileDevExam.WebApp.Services.Security
{
  public interface IUserService : IDataService<User>
  {
    UserAuthenticationInfo Authenticate(ICredential credential);
    Task<UserAuthenticationInfo> AuthenticateAsync(ICredential credential);
    bool Authenticate(string token);
    Task<bool> AuthenticateAsync(string token);
  }
}
