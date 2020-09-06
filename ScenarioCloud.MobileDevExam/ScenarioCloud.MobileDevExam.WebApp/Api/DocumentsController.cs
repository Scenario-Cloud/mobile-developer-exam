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
    public class DocumentsController : ApiController
    {
      [HttpGet]
      public async Task<IEnumerable<Document>> Index(int? id = null)
      {
        IEnumerable<Document> documents;
        using (var context  = new ScenarioDbContext(ScenarioConstants.ConnectionName))
        {
          var service = new DocumentService(context);
          if (id == null)
            documents = await service.GetAsync(d => d.Id > 0);
          else
            documents = await service.GetAsync(d => d.Id == id);
        }
        return documents;
      }
    }
}