using System;

namespace ScenarioCloud.MobileDevExam.Business.Security
{
  public interface IUserToken : IEntity
  {
    int UserId { get; set; }
    User User { get; set; }
    string Token { get; set; }
    DateTime DateIssued { get; set; }
    DateTime ExpiryDate { get; set; }
  }
}
