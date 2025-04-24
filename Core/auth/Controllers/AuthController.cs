using Microsoft.AspNetCore.Mvc;
using SimpleSocialBoardServer.Areas.Member.Models.DTOs;
using SimpleSocialBoardServer.Areas.Member.Services;
using SimpleSocialBoardServer.Core.auth.Services;
using SimpleSocialBoardServer.Core.ViewModel;
using SimpleSocialBoardServer.Settings;
using SimpleSocialBoardServer.Shared.Helpers;

namespace SimpleSocialBoardServer.Core.auth.Controllers
{



    [Route("[controller]")]
    public class AuthController (AuthService authService,UserService userService, ILogger<AuthController> logger) : ControllerBase
    {
        private readonly UserService _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        private readonly AuthService _authService = authService ?? throw new ArgumentNullException(nameof(authService));

        private readonly ILogger<AuthController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        //登入
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            // 這裡可以添加登入邏輯，例如驗證帳號和密碼
            // 如果登入成功，返回 JWT 或其他認證令牌
            var user = _userService.FindByAccount(dto.Account).Result;
            // 驗證帳號和密碼
            if (user != null && BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                //登入成功，回傳token
                var token = JwtHelper.GenerateToken(
                    user.Account,  //帳號 
                    "Member",      //角色
                    JwtSettings.Key,  //密鑰，這裡需要替換成實際的密鑰
                    JwtSettings.Issuer,     //發行者，這裡需要替換成實際的發行者
                    JwtSettings.Audience,   //受眾，這裡需要替換成實際的受眾
                    JwtSettings.Jwt_Expire);
                return Ok(ApiResponse<string>.Ok(token));

            }else {
                return Unauthorized(ApiResponse<string>.Fail("Error 401:帳號或密碼錯誤"));
            }
        }

    }


}