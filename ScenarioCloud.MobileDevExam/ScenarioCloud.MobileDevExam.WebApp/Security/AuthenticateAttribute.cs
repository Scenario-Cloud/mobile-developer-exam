using ScenarioCloud.MobileDevExam.Data;
using ScenarioCloud.MobileDevExam.WebApp.Services.Security;
using ScenarioCloud.MobileDevExam.WebApp.Utilities;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ScenarioCloud.MobileDevExam.WebApp.Security
{
  public class AuthenticateAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
      var request = HttpContext.Current?.Request;
      if (request?.Headers != null)
      {
        var requestToken = request.Headers["Token"];
        var validToken = false;

        using (var context = new ScenarioDbContext(ScenarioConstants.ConnectionName))
        {
          var userService = new UserService(context);
          validToken = userService.Authenticate(requestToken);
        }

        if (!validToken)
          actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
      }
    }
  }
}