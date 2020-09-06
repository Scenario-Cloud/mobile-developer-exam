namespace ScenarioCloud.MobileDevExam.Business
{
  public interface IDocument : IEntity
  {
    string DocumentNo { get; set; }
    string Subject { get; set; }
    string Description { get; set; }
    int RegisterId { get; set; }
    Register Register { get; set; }
    int ProjectId { get; set; }
    Project Project { get; set; }
  }
}
