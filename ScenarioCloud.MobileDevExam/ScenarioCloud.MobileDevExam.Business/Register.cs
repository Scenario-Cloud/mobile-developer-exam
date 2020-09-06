using System.ComponentModel.DataAnnotations;

namespace ScenarioCloud.MobileDevExam.Business
{
  public class Register : Entity, IRegister
  {
    [Required,
     StringLength(30)]
    public string Code { get; set; }
    [Required,
     StringLength(255)]
    public string Description { get; set; }
  }
}
