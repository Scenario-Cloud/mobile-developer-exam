using System.ComponentModel.DataAnnotations;

namespace ScenarioCloud.MobileDevExam.Business.Security
{
  public class User : Credential, IUser
  {
    [Key]
    public int Id { get; set; }
    [Required,
     StringLength(150)]
    public string AccountHolder { get; set; }    
  }
}
