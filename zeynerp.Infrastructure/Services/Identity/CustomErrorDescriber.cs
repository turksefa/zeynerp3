using Microsoft.AspNetCore.Identity;

namespace zeynerp.Infrastructure.Services.Identity
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email) => new IdentityError
        {
                Code = nameof(DuplicateEmail),
                Description = $"{email} e-posta adresi zaten kullanılmaktadır."
        };

        public override IdentityError DuplicateUserName(string userName) => new IdentityError
        {
                Code = nameof(DuplicateUserName),
                Description = $"{userName} kullanıcı adı zaten kullanılmaktadır."
        };

        public override IdentityError PasswordTooShort(int length) => new IdentityError
        {
                Code = nameof(PasswordTooShort),
                Description = $"Şifre en az {length} karakter uzunluğunda olmalıdır."
        };

        public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError
        {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "Şifre en az bir alfanümerik olmayan karakter içermelidir."
        };

        public override IdentityError PasswordRequiresDigit() => new IdentityError
        {
                Code = nameof(PasswordRequiresDigit),
                Description = "Şifre en az bir rakam içermelidir."
        };

        public override IdentityError PasswordRequiresLower() => new IdentityError
        {
                Code = nameof(PasswordRequiresLower),
                Description = "Şifre en az bir küçük harf içermelidir."
        };

        public override IdentityError PasswordRequiresUpper() => new IdentityError
        {
                Code = nameof(PasswordRequiresUpper),
                Description = "Şifre en az bir büyük harf içermelidir."
        };
    }
}