using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleSocialBoardServer.Areas.Member.Models.DTOs;
using SimpleSocialBoardServer.Areas.Member.Services;
using SimpleSocialBoardServer.Core.ViewModel;

namespace SimpleSocialBoardServer.Areas.Member.Controllers
{

    // 將jwt授權套用至UserController
    [Authorize]
    [Area("Member")]
    [Route("[area]/[controller]")]
    public class UserController(UserService userService, ILogger<UserController> logger) : ControllerBase
    {
        private readonly UserService _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        private readonly ILogger<UserController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        //取得使用者資訊
        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo(int userId)
        {
            
            return Ok("GetUserInfo");
        }
    }


}