using UserService.Models;

namespace UserService.Abstractions
{
    public interface IUserAuthenticationService
    {
        UserModel Authenticate(LoginModel loginModel);
    }
}
