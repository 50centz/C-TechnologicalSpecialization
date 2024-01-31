using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UserService.Abstractions;
using UserService.Db;
using UserService.Models;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserController(IConfiguration configuration, IUserRepository userRepository)
        {
            this._configuration = configuration;
            _userRepository = userRepository;

        }


        [HttpGet]
        [Route("AllUsers")]
        [Authorize(Roles = "Administrator")]
        public ActionResult AllUsers()
        {
            
            try
            {
                var users = _userRepository.AllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
 
        }

        [HttpDelete]
        [Route("DeleteUser")]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteUser(string name)
        {
            try
            {
                _userRepository.DeleteUser(name);
                return Ok();
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /*
         * Метод возвращающий ID пользователя при обращении с
            JWT-токеном (для проверки работоспособности API)
        Я переделал этот метод, он возвращает имя пользователя
         */

        [HttpGet]
        [Route("GetId")]
        [Authorize(Roles = "Administrator, User")]
        public ActionResult<string> GetId(string name)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                var name1 = _userRepository.CheckUser(identity);
                return Ok(name1);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}
