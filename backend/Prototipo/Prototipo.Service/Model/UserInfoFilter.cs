using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Service.Model
{
  public class UserInfoFilter
  {
    public string? UserName { get; set; }
    public string? Gender { get; set; }
    public DateTime? DOB { get; set; }
  }
}
