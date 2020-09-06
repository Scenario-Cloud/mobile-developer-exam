using ScenarioCloud.MobileDevExam.Business.Security;
using ScenarioCloud.MobileDevExam.Data;
using ScenarioCloud.MobileDevExam.WebApp.Services.Security;
using ScenarioCloud.MobileDevExam.WebApp.Utilities;
using System.Threading.Tasks;
using System.Web.Http;

namespace ScenarioCloud.MobileDevExam.WebApp.Api
{
    public class AuthenticationController : ApiController
    {
      [HttpPost]
      public async Task<IHttpActionResult> Index(Credential credential)
      {
        IHttpActionResult response;
        using (var context = new ScenarioDbContext(ScenarioConstants.ConnectionName))
        {
          var service = new UserService(context);
          try
          {
            var authentication = await service.AuthenticateAsync(credential);
            response = Ok(authentication);
          }
          catch
          {
            response = BadRequest();
          }
        }
        return response;
      }
    }
}
