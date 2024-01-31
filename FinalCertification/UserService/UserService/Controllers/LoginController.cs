using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UserService.Abstractions;
using UserService.Db;
using UserService.Models;

namespace UserService.Controllers
{
    public static class RSATools
    {
        public static RSA GetPrivateKey()
        {
            var f = File.ReadAllText("rsa/private_key.pem");
            var rsa = RSA.Create();
            rsa.ImportFromPem(f);
            return rsa;
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public LoginController(IConfiguration configuration,  IUserRepository userRepository)
        {
            this._configuration = configuration;
            _userRepository = userRepository;

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] LoginModel userLogin)
        {
            try
            {
                var roleId = _userRepository.UserCheck(userLogin.Name, userLogin.Password);
                var user = new UserModel { UserName = userLogin.Name, Role = RoleIDToRole(roleId) };

                var token = GenerateToken(user);
                return Ok(token);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private UserRole RoleIDToRole(RoleId roleId)
        {
            if (roleId == RoleId.Admin)
            {
                return UserRole.Administrator;
            }
            return UserRole.User;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("AddAdmin")]
        public ActionResult AddAdmin([FromBody] LoginModel userLogin) 
        {
            try
            {
                _userRepository.UserAdd(userLogin.Name, userLogin.Password, RoleId.Admin);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }


        
        [HttpPost]
        [Route("AddUser")]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddUser([FromBody] LoginModel userLogin)
        {
            try
            {
                _userRepository.UserAdd(userLogin.Name, userLogin.Password, RoleId.User);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }



        private string GenerateToken(UserModel userModel)
        {
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var securityKey = new RsaSecurityKey(RSATools.GetPrivateKey());
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256Signature);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userModel.UserName),
                new Claim(ClaimTypes.Role, userModel.Role.ToString())
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

            
        }
    }
}
