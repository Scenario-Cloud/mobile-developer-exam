using System;

namespace ScenarioCloud.MobileDevExam.WebApp.Models.Security
{
  public class UserAuthenticationInfo : IUserAuthenticationInfo
  {
    public string AccountHolder { get; set; }
    public string Token { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime ExpiryDate { get; set; }
  }
}