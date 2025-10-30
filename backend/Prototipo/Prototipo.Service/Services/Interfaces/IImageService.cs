using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Service.Services.Interfaces
{
  public interface IImageService
  {
    Task<string> UploadFileImages(IFormFile file, int reportId);
  }
}
