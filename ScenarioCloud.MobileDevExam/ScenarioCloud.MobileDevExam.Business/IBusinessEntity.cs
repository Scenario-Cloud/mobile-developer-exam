namespace ScenarioCloud.MobileDevExam.Business
{
  public interface IBusinessEntity : IEntity
  {
    string Name { get; set; }
    string Description { get; set; }
  }
}
