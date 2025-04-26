using FluentValidation;
using SimpleSocialBoardServer.Core.auth.Models;

namespace SimpleSocialBoardServer.Core.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Account)
                .NotEmpty().WithMessage("帳號不能為空")
                .MinimumLength(3).WithMessage("帳號長度必須大於等於 3 個字元")
                .MaximumLength(16).WithMessage("帳號長度必須小於等於 16 個字元");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("密碼不能為空");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("姓名不能為空");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("姓名不能為空")
                .EmailAddress().WithMessage("請輸入有效的電子郵件地址");

            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage("生日不能為空");    
        }
    }
}