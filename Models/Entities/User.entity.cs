using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSocialBoardServer.Models.Entities
{


    public class User
    {
        /// 使用者主鍵。
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// 帳號。
        [Required]
        public required string Account { get; set; }

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