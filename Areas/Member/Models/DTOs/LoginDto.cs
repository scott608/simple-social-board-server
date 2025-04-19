
namespace SimpleSocialBoardServer.Areas.Member.Models.DTOs
{
    public class LoginDto
    {

        /// 帳號。
        public required string Account { get; set; }

        /// 密碼。
        public required string Password { get; set; }

    }
}