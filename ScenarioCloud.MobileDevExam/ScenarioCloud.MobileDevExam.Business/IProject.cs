namespace ScenarioCloud.MobileDevExam.Business
{
  public interface IProject : IEntity
  {
    int BusinessEntityId { get; set; }
    BusinessEntity BusinessEntity { get; set; }
    string ProjectNo { get; set; }
    string Name { get; set; }
  }
}
