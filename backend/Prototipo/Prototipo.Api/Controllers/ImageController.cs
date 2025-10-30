using Microsoft.AspNetCore.Mvc;
using Prototipo.Service.Services.Interfaces;

namespace Prototipo.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ImageController : ControllerBase
  {
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
     _imageService = imageService;
    }

    [HttpPost("upload/report/{reportId}")]
    public async Task<IActionResult> UploadFile(IFormFile file, [FromRoute] int reportId)
    {
      string result = await _imageService.UploadFileImages(file, reportId);
      
      if (result == "-1")
      {
        return BadRequest("File non valido perche vuoto...!");
      }
      //todo .... tutte le altre risposte


      return Created("", result);
    }
  }
}
