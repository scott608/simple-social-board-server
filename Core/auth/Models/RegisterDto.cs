
namespace SimpleSocialBoardServer.Core.auth.Models
{
    public class RegisterDto
    {
        /// 帳號。
        public required string Account { get; set; }

        /// 密碼。
        public required string Password { get; set; }

        /// 姓名。
        public required string Name { get; set; }

        /// 信箱。
        public required string Email { get; set; }

        /// 性別。
        public Gender Gender { get; set; }

        /// 出生日期。
        public required string Birthday { get; set; }

    }
}