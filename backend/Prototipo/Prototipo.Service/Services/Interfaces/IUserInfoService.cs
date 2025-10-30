using Prototipo.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Service.Services.Interfaces
{
  public interface IUserInfoService
  {
    Task<int> AddUserInfo(UserInfoDTO addEntity);
    Task<UserInfoViewModel> GetById(int id);
    Task<List<UserInfoViewModel>> GetByFilter(UserInfoFilter filter);
    Task<int> UpdatePatch(UserInfoUpdateDTO updateEntity, int id);
    Task<int> Delete(int id);
  }
}
