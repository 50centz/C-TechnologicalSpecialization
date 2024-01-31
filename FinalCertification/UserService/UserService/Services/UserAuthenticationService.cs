using UserService.Abstractions;
using UserService.Models;

namespace UserService.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public UserModel Authenticate(LoginModel loginModel)
        {
            if (loginModel.Name == "admin" && loginModel.Password == "password") 
            {
                return new UserModel { Password = loginModel.Password, UserName = loginModel.Name, Role = UserRole.Administrator };
            }

            if (loginModel.Name == "user" && loginModel.Password == "super")
            {
                return new UserModel { Password = loginModel.Password, UserName = loginModel.Name, Role = UserRole.User };
            }
            return null;
        }
    }
}
