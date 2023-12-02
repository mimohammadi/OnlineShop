using Service.Dto;

namespace Service.Interface
{
    public interface IUserService
    {
        Task RegisterUser(UserRegisterDto dto);
        Task<UserTokenDto> Login(UserLoginDto dto);
    }
}
