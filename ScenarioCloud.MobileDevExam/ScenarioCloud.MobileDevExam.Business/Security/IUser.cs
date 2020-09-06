namespace ScenarioCloud.MobileDevExam.Business.Security
{
  public interface IUser : IEntity, ICredential
  {
    string AccountHolder { get; set; }
  }
}
