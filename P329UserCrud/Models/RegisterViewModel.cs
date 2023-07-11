using System.ComponentModel.DataAnnotations;

namespace P329UserCrud.Models
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Country { get; set; }
    }
}
