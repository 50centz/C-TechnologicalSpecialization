using Microsoft.AspNetCore.Http.HttpResults;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UserService.Abstractions;
using UserService.Db;
using UserService.Models;

namespace UserService.Services
{
    public class UserRepository : IUserRepository
    {
        
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        
        public void UserAdd(string username, string password, RoleId roleId)
        {
            bool response =  UserCheckLogin(username);
            if (!response)
            {
                throw new Exception("Этот логин занят");
            }
            using (_context)
            {
                if (roleId == RoleId.Admin)
                {
                    var c = _context.Users.Count(e => e.RoleId == RoleId.Admin);
                    if (c > 0)
                    {
                        throw new Exception("Администратор может быть только  один");
                    }
                }

                var user = new User();
                user.Name = username;
                user.RoleId = roleId;

                user.Salt = new byte[32];
                new Random().NextBytes(user.Salt);

                var data = Encoding.ASCII.GetBytes(password).Concat(user.Salt).ToArray();

                SHA512 shaM = new SHA512Managed();
                user.Password = shaM.ComputeHash(data);

                _context.Add(user);
                _context.SaveChanges();
            }
        }

        public RoleId UserCheck(string username, string password)
        {
            using (_context)
            {
                var user = _context.Users.FirstOrDefault(e => e.Name == username);
                if (user == null)
                {
                    throw new Exception("user not found");
                }

                var data = Encoding.ASCII.GetBytes(password).Concat(user.Salt).ToArray();
                SHA512 shaM = new SHA512Managed();
                var bpassword = shaM.ComputeHash(data);

                if (user.Password.SequenceEqual(bpassword))
                {
                    return user.RoleId;
                }
                else
                {
                    throw new Exception("Wrong password");
                }

            }
        }

        private bool UserCheckLogin(string username)
        {
            using (_context)
            {
                var user = _context.Users.FirstOrDefault(e => e.Name == username);
                if (user == null)
                {
                    return true;
                }
                
                return false;
                
            }
        }


        public List<User> AllUsers()
        {
            using (_context)
            {
                List<User> users = _context.Users.Select(e =>  new User { Name = e.Name, Password = e.Password, RoleId = e.RoleId }).ToList();
                return users;
            }
        }

        public void DeleteUser(string name)
        {
            using (_context)
            {
                var user = _context.Users.FirstOrDefault(x => x.Name == name);
                if (user == null)
                {
                    throw new Exception("Пользователя с таким логином не существует");
                }
                if (user.RoleId == RoleId.Admin)
                {
                    throw new Exception("Администратора нельзя удалить");
                }
                else
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            }
        }

        public string CheckUser(ClaimsIdentity claimsIdentity)
        {
            
            if (claimsIdentity != null)
            {
                var userClaims = claimsIdentity.Claims;
                var UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                return UserName;
                
            }
            return null;
        }
    }
}
