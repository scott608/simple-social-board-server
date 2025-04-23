using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleSocialBoardServer.Shared.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateToken(string account, string role, string key, string issuer, string audience, int expireMinutes)
        {
            //創建一個ClaimsIdentity，這裡可以添加用戶的相關資訊
            //例如用戶名、角色等
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, account),
                new Claim(ClaimTypes.Role, role)
            };
            //使用對稱密鑰進行簽名
            var keyBytes = Encoding.UTF8.GetBytes(key);
            //這裡的keyBytes是從環境變數中獲取的密鑰，這個密鑰應該是保密的，不應該公開
            //這裡的issuer和audience是用來驗證JWT的發行者和受眾的，這些值應該是固定的
            var creds = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes), 
                SecurityAlgorithms.HmacSha256
                );
            //創建JWT的實例，這裡可以設置過期時間、發行者、受眾等資訊
            //這裡的expires是設置JWT的過期時間，這裡設置為當前時間加上過期時間    
            var token = new JwtSecurityToken(
                issuer, 
                audience, 
                claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

