using System;

namespace ScenarioCloud.MobileDevExam.WebApp.Models.Security
{
  public interface IUserAuthenticationInfo
  {
    string AccountHolder { get; set; }
    string Token { get; set; }
    DateTime DateIssued { get; set; }
    DateTime ExpiryDate { get; set; }
  }
}
