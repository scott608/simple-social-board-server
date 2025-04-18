using SimpleSocialBoardServer.Areas.Member.Models.DTOs;
using SimpleSocialBoardServer.Data;
using SimpleSocialBoardServer.Areas.Member.Models.Entities;

namespace SimpleSocialBoardServer.Areas.Member.Services
{
      public class UserService{
        private readonly MainDbContext _db;

        public UserService(MainDbContext db)
        {
            _db = db;
        }
        // public async Task<UserEntity> RegisterAsync(LoginDto dto)
        // {
        //     var user = new UserEntity
        //     {
        //         Account = dto.Account,
        //         Password = dto.Password, // 這邊未加密，之後建議加密！
        //         Name = dto.Name
        //     };

        //     _db.Users.Add(user);
        //     await _db.SaveChangesAsync();

        //     return user;
        // }


      }


}