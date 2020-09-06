using ScenarioCloud.MobileDevExam.Business;
using ScenarioCloud.MobileDevExam.Data;

namespace ScenarioCloud.MobileDevExam.WebApp.Services.Business
{
  public class DocumentService : DataService<Document>, IDocumentService
  {
    public DocumentService(IScenarioDbContext dbContext) : base(dbContext)
    { }
  }
}