using System.ComponentModel.DataAnnotations;

namespace ScenarioCloud.MobileDevExam.Business
{
  public class BusinessEntity : Entity, IBusinessEntity
  {
    [Required,
     StringLength(100)]
    public string Name { get; set; }
    [StringLength(255)]
    public string Description { get; set; }
  }
}
