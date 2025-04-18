
namespace SimpleSocialBoardServer.Areas.Member.Models.DTOs
{
    public class UserDto
    {
        /// 使用者主鍵。
        public int UserId { get; set; }

        /// 帳號。
        public required string Account { get; set; }

        /// 密碼。
        public required string Password { get; set; }

        /// 姓名。
        public required string Name { get; set; }

        /// 英文姓名。
        public string? EnName { get; set; }

        /// 電話。
        public string? Phone { get; set; }

        /// 地址。
        public string? Address { get; set; }

        /// 信箱。
        public required string Email { get; set; }

        /// 照片路徑。
        public string? AvatarUrl { get; set; }

        /// 性別。
        public Gender Gender { get; set; }

        /// 出生日期。
        public required string Birthday { get; set; }

        /// 身分證字號。
        public required string IdCard { get; set; }

        /// 備註。
        public string? Remark { get; set; }
    }
}