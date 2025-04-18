using Microsoft.AspNetCore.Mvc;

namespace SimpleSocialBoardServer.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("[area]/[controller]")]
    public class UserController : ControllerBase
    {
        //取得使用者資訊
        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo(int userId)
        {
            // 這裡可以使用依賴注入來獲取資料庫上下文
            // var user = _dbContext.Users.Find(userId);
            // if (user == null)
            // {
            //     return NotFound();
            // }
            // return Ok(user);
            return Ok("GetUserInfo");
        }
    }


}