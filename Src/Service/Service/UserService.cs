using Common.Models;
using Domain;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Dto;
using Service.Interface;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly ApplicationSettingsModel _settings;

        public UserService(IRepository<User> repository,
            IConfiguration configuration)
        {
            _repository = repository;
            _settings = configuration.GetSection("ApplicationSettings").Get<ApplicationSettingsModel>();
        }

        public  Task<UserTokenDto> Login(UserLoginDto dto)
        {
            throw new NotImplementedException();
            //var user =
            //    await _repository.GetAll();
            //      //  .FirstOrDefaultAsync(x => x.Username == username && x.Password == password.ToMd5() && x.UserRoles.Any(y => y.RoleId == selectedRoleId));

            //if (user == null)
            //    throw new InvalideUserNameAndPassword();

            //return await CreateToken(user, selectedRoleId);
        }

        public Task RegisterUser(UserRegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
