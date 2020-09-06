namespace ScenarioCloud.MobileDevExam.Business
{
  public interface IRegister : IEntity
  {
    string Code { get; set; }
    string Description { get; set; }
  }
}
