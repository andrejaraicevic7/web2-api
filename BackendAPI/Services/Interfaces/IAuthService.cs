using BackendAPI.DTO;

namespace BackendAPI.Services.Interfaces
{
    public interface IAuthService
    {
        string Login(LoginDto loginDTO);
        void Register(UserDto accountDTO);
        string SocialLogin(UserDto accountDTO);
    }
}
