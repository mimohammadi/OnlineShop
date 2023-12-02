using System.ComponentModel.DataAnnotations;

namespace Service.Dto
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "لطفا شماره همراه خود را وارد نمایید")]
        public string CellPhoneNumber { get; set; }

        [Required(ErrorMessage = "لطفا پسورد خود را وارد نمایید")]
        public string Password { get; set; }
    }

    public class UserTokenDto
    {
        public long Id { get; set; }
        public string CellPhoneNumber { get; set; }
        public string AccessToken { get; set; }
    }

    public class UserLoginDto
    {
        [Required(ErrorMessage = "لطفا شماره همراه خود را وارد کنید")]
        public string CellPhoneNumber { get; set; }

        [Required(ErrorMessage = "لطفا پسورد خود را وارد نمایید")]
        public string Passwod { get; set; }
    }
}
