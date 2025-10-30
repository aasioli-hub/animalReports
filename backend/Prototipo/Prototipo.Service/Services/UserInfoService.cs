using Microsoft.EntityFrameworkCore;
using Prototipo.Service.Entities;
using Prototipo.Service.Model;
using Prototipo.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Prototipo.Service.Services
{
  public class UserInfoService : IUserInfoService
  {
    private readonly DatabaseContext _context;

    public UserInfoService(DatabaseContext context)
    {
      _context = context;
    }

    public async Task<int> AddUserInfo(UserInfoDTO addEntity)
    {
      bool exist = await _context.UserInfo.AsQueryable().Where(x => x.UserName == addEntity.UserName).AnyAsync();

      if (exist == true)
      {
        return -1;
      }

      Random random = new Random();
      int idRandom = random.Next();
      var entityToAdd = new UserInfo
      {
        Id = idRandom,
        UserName = addEntity.UserName,
        DOB = addEntity.DOB.ToUniversalTime(),
        Gender = addEntity.Gender
      };

      await _context.UserInfo.AddAsync(entityToAdd);

      await _context.SaveChangesAsync();

      return entityToAdd.Id;

    }

    public async Task<int> Delete(int id)
    {
      UserInfo? entity = await _context.UserInfo.FindAsync(id);

      if (entity == null)
      {
        return -1;
      }

      _context.Remove(entity);

      await _context.SaveChangesAsync();

      return entity.Id;
    }

    public async Task<List<UserInfoViewModel>> GetByFilter(UserInfoFilter filter)
    {
      IQueryable<UserInfo> query = _context.UserInfo.AsQueryable();

      if (filter.DOB != null)
      {
        query = query.Where(x => x.DOB == filter.DOB);
      }
      if (!string.IsNullOrWhiteSpace(filter.UserName))
      {
        query = query.Where(x => x.UserName == filter.UserName);
      }
      if (!string.IsNullOrWhiteSpace(filter.Gender))
      {
        query = query.Where(x => x.Gender == filter.Gender);
      }


      List<UserInfo> list = await query.ToListAsync();


      List<UserInfoViewModel> listViewModel = list.Select(x => new UserInfoViewModel
      {
        UserName = x.UserName,
        DOB = x.DOB,
        Gender = x.Gender,
        Id = x.Id,
      }).ToList();


      return listViewModel;
    }

    public async Task<UserInfoViewModel> GetById(int id)
    {
      UserInfo? entity = await _context.UserInfo.FindAsync(id);

      UserInfoViewModel entityViewModel = null;
      if (entity != null)
      {
        entityViewModel = new UserInfoViewModel
        {
          Id = entity.Id,
          Gender = entity.Gender,
          DOB = entity.DOB,
          UserName = entity.UserName,
        };
      }
      
      return entityViewModel;
    }

    public async Task<int> UpdatePatch(UserInfoUpdateDTO updateEntity, int id)
    {
      UserInfo? entity = await _context.UserInfo.FindAsync(id);

      if (entity == null)
      {
        return -1;
      }

      if (updateEntity.DOB != null)
      {
        entity.DOB = updateEntity.DOB.Value;
      }
      if (!string.IsNullOrWhiteSpace(updateEntity.UserName))
      {
        entity.UserName = updateEntity.UserName;
      }
      if (!string.IsNullOrWhiteSpace(updateEntity.Gender))
      {
        entity.Gender = updateEntity.Gender;
      }

      _context.UserInfo.Update(entity);

      await _context.SaveChangesAsync();

      return entity.Id;
    }
  }
}
