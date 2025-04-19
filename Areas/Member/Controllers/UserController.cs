using Microsoft.AspNetCore.Mvc;
using SimpleSocialBoardServer.Areas.Member.Models.DTOs;
using SimpleSocialBoardServer.Areas.Member.Services;
using SimpleSocialBoardServer.Core.ViewModel;

namespace SimpleSocialBoardServer.Areas.Member.Controllers
{



    [Area("Member")]
    [Route("[area]/[controller]")]
    public class UserController(UserService userService, ILogger<UserController> logger) : ControllerBase
    {
        private readonly UserService _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        private readonly ILogger<UserController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        //註冊
        [HttpPost("Register")] 
        public async Task<IActionResult> RegisterAsync([FromBody] UserDto dto)
        {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Error 400:註冊資料驗證失敗");
                    return BadRequest(ApiResponse<string>.Fail("Error 400:註冊資料驗證失敗" + ModelState));
                }
                var success = await _userService.RegisterAsync(dto);

                if (success == null)
                {
                    _logger.LogWarning("Error 409:帳號 {Account} 已存在", dto.Account);
                    return Conflict(ApiResponse<string>.Fail("帳號已存在"));
                }
                _logger.LogInformation("帳號 {Account} 註冊成功", dto.Account);
                return Ok(ApiResponse<string>.Ok("註冊成功"));
        }

        //登入
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            // 這裡可以添加登入邏輯，例如驗證帳號和密碼
            // 如果登入成功，返回 JWT 或其他認證令牌
            var user = _userService.FindByAccountAsync(dto.Account).Result;
            if (user == null || user.Password != dto.Password)
            {
                return Unauthorized(ApiResponse<string>.Fail("Error 401:帳號或密碼錯誤"));
            }
            return Ok(ApiResponse<string>.Ok("登入成功"));
        }


        //取得使用者資訊
        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo(int userId)
        {
            
            return Ok("GetUserInfo");
        }
    }


}