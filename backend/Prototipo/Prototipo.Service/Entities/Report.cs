using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Service.Entities
{
  public class Report
  {
    public int Id { get; set; }
    public string Title { get; set; }

    public virtual ICollection<Image> Images { get; set; }
  }
}
