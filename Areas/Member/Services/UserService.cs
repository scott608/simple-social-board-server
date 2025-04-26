using SimpleSocialBoardServer.Data;
using Microsoft.EntityFrameworkCore;
using SimpleSocialBoardServer.Core.Entities;

namespace SimpleSocialBoardServer.Areas.Member.Services
{
      public class UserService(MainDbContext db)
    {
        private readonly MainDbContext _db = db ?? throw new ArgumentNullException(nameof(db));

        //取得使用者資料(帳號)
        public Task<UserEntity?> FindByAccount(string account)
        {
            // 使用 EF Core 的 LINQ 查詢來獲取使用者資料
            return _db.Users
                .FirstOrDefaultAsync(u => u.Account == account);
        }


    }


}