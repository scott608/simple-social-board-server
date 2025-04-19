using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSocialBoardServer.Areas.Member.Models.Entities
{
    [Table("user")]
    public class UserEntity 
    {
        [Key]
        [Column("userId")]
        // user主鍵
        public int UserId { get; set; }

        [Required]
        [MaxLength(16)]
        [Column("account")]
        // 帳號
        public string Account { get; set; } = string.Empty;

        [Required]
        [Column("password")]
        // 密碼
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("name")]
        // 姓名
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("enName")]
        // 英文姓名
        public string? EnName { get; set; }

        [MaxLength(20)]
        [Column("phone")]
        // 電話
        public string? Phone { get; set; }

        [Column("address")]
        // 地址
        public string? Address { get; set; }

        [Required]
        [Column("email")]
        // 信箱
        public string Email { get; set; } = string.Empty;

        [Column("avatarUrl")]
        // 照片路徑
        public string? AvatarUrl { get; set; }

        [Required]
        [Column("gender")]
        // 性別
        public string Gender { get; set; } = "Male";

        [Required]
        [MaxLength(20)]
        [Column("birthday")]
        // 出生日期
        public string Birthday { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Column("idCard")]
        // 身分證字號
        public string IdCard { get; set; } = string.Empty;

        [Column("remark")]
        // 備註
        public string? Remark { get; set; }
    }

}