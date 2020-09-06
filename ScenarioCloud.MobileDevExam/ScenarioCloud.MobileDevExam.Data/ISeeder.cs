using ScenarioCloud.MobileDevExam.Business;
using System.Collections.Generic;

namespace ScenarioCloud.MobileDevExam.Data
{
  public interface ISeeder<T> : IDataSeeder where T : class, IEntity
  {
    IEnumerable<T> DefaultItems { get; set; }
  }
}
