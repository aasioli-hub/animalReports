using Microsoft.AspNetCore.Mvc;
using Prototipo.Service.Model;
using Prototipo.Service.Services.Interfaces;

namespace Prototipo.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserInfoController : ControllerBase
  {
    private readonly IUserInfoService _service;

    public UserInfoController(IUserInfoService service)//todo aggiungere logger....
    {
      _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserInfoDTO addEntity)
    {
      int result = await _service.AddUserInfo(addEntity);

      if (result == -1)
      {
        return BadRequest("ERRORE: UserName gia esistente!");
      }

      return Created("", result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      UserInfoViewModel? result = await _service.GetById(id);

      if (result == null)
      {
        return NotFound("Attenzione UserInfo non trovato!");
      }

      return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromQuery] UserInfoFilter filter)
    {
      List<UserInfoViewModel>? result = await _service.GetByFilter(filter);

      if (result == null || !result.Any())
      {
        return NoContent();
      }

      return Ok(result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePatch([FromRoute]int id, [FromBody] UserInfoUpdateDTO updateEntity)
    {
      int result = await _service.UpdatePatch(updateEntity, id);

      if (result == -1)
      {
        return BadRequest("ERRORE: UserInfo da aggiornare richiesto non esistente!");
      }

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      int result = await _service.Delete(id);

      if (result == -1)
      {
        return BadRequest("ERRORE: UserInfo da eliminare richiesto non esistente!");
      }

      return NoContent();
    }
  }
}
