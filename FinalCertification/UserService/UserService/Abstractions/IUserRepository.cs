using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserService.Db;

namespace UserService.Abstractions
{
    public interface IUserRepository
    {
        public void UserAdd(string username, string password, RoleId roleId);
        public RoleId UserCheck(string username, string password);
        public List<User> AllUsers();

        public void DeleteUser(string name);

        public string CheckUser(ClaimsIdentity claimsIdentity);

        
    }
}
