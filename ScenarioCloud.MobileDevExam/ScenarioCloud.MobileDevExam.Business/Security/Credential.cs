using System.ComponentModel.DataAnnotations;

namespace ScenarioCloud.MobileDevExam.Business.Security
{
  public class Credential : ICredential
  {
    [Required,
     StringLength(100)]
    public string Username { get; set; }
    [Required,
     StringLength(150)]
    public string Password { get; set; }
  }
}
