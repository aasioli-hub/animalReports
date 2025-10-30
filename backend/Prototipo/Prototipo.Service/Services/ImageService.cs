using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prototipo.Service.Entities;
using Prototipo.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Service.Services
{
  public class ImageService : IImageService
  {
    private readonly DatabaseContext _context;
    private readonly IConfiguration _configuration;

    public ImageService(DatabaseContext context, IConfiguration configuration)
    {
      _configuration = configuration;
      _context = context;
    }

    public async Task<string> UploadFileImages(IFormFile file, int reportId)
    {
      if (file.Length < 1)
      {
        return await Task.FromResult("-1");
      }

      bool exist = await _context.Report.Where(x => x.Id == reportId).AnyAsync();
      if (exist == false)
      {
        return await Task.FromResult("-2");
      }

      string? filePath = _configuration["FilePath"];
      if (string.IsNullOrWhiteSpace(filePath))
      {
        return await Task.FromResult("-3");
      }

      if (!Directory.Exists(filePath))
      {
        return await Task.FromResult("-4");
      }


      string filePathFull = Path.Combine(filePath, file.FileName);



      //todo BEGIN transazione

      var imageEntity = new Image
      {
        ReportId = reportId,
        Path = filePathFull
      };
      await _context.Image.AddAsync(imageEntity);
      await _context.SaveChangesAsync();


      using (Stream fileStream = new FileStream(filePathFull, FileMode.Create))
      {
        await file.CopyToAsync(fileStream);
      }


      //todo COMMIT transazione



      //se fallisce una delle 2 operazioni ROLLBACK


      return filePathFull;      
    }
  }
}
