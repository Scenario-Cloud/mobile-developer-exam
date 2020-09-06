using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScenarioCloud.MobileDevExam.Business
{
  public class Project : Entity, IProject
  {
    public int BusinessEntityId { get; set; }
    [ForeignKey(nameof(BusinessEntityId))]
    public virtual BusinessEntity BusinessEntity { get; set; }
    [Required,
     StringLength(20)]
    public string ProjectNo { get; set; }
    [Required,
     StringLength(150)]
    public string Name { get; set; }
  }
}
