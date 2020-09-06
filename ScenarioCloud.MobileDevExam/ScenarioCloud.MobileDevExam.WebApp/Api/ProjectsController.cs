using ScenarioCloud.MobileDevExam.Business;
using ScenarioCloud.MobileDevExam.Data;
using ScenarioCloud.MobileDevExam.WebApp.Security;
using ScenarioCloud.MobileDevExam.WebApp.Services.Business;
using ScenarioCloud.MobileDevExam.WebApp.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ScenarioCloud.MobileDevExam.WebApp.Api
{
    [Authenticate]
    public class ProjectsController : ApiController
    {
      [HttpGet]
      public async Task<IEnumerable<Project>> Index(int? id = null)
      {
        IEnumerable<Project> results;
        using (var context = new ScenarioDbContext(ScenarioConstants.ConnectionName))
        {
          var service = new ProjectService(context);
          if (id == null)
            results = await service.GetAsync(p => p.Id > 0);
          else
            results = await service.GetAsync(p => p.Id == id);
        }
        return results;
      }
    }
}
