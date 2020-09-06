using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScenarioCloud.MobileDevExam.Business
{
  public class Document : Entity, IDocument
  {
    [Required,
     StringLength(100)]
    public string DocumentNo { get; set; }
    [Required,
     StringLength(150)]
    public string Subject { get; set; }
    [StringLength(255)]
    public string Description { get; set; }
    public int RegisterId { get; set; }
    [ForeignKey(nameof(RegisterId))]
    public virtual Register Register { get; set; }
    public int ProjectId { get; set; }
    [ForeignKey(nameof(ProjectId))]
    public virtual Project Project { get; set; }
  }
}
