using SimpleSocialBoardServer.Areas.Member.Models.DTOs;
using SimpleSocialBoardServer.Data;
using SimpleSocialBoardServer.Areas.Member.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SimpleSocialBoardServer.Core.auth.Services
{
      public class AuthService(MainDbContext db)
    {
        private readonly MainDbContext _db = db ?? throw new ArgumentNullException(nameof(db));

        public async Task<UserEntity?> RegisterAsync(UserDto dto)
        {
            // 檢查帳號是否存在
            var existingUser = await _db.Users
                .FirstOrDefaultAsync(u => u.Account == dto.Account);
            if (existingUser != null)
            {
                // 帳號已存在，返回 null 或拋出例外
                return null;
            }
            // 使用 BCrypt 加密密碼
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var user = new UserEntity
            {  
                //註冊時，帳號、密碼、姓名、英文姓名、電話、地址、信箱都必填
                // 其他欄位可以選擇性填寫
                Account = dto.Account,
                Password = hashedPassword,
                Name = dto.Name,
                EnName = dto.EnName,
                Phone = dto.Phone,
                Address = dto.Address,
                Email = dto.Email,
                Gender= dto.Gender.ToString()
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user;
        }

    }


}