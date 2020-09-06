using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScenarioCloud.MobileDevExam.Business.Security
{
  public class UserToken : Entity, IUserToken
  {
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
    [Required,
     StringLength(255)]
    public string Token { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime ExpiryDate { get; set; }
  }
}
