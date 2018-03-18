using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto )
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

            if(await _repo.UserExists(userForRegisterDto.UserName))
            {
                ModelState.AddModelError("UserName", "UserName already exists");
            }
          
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            

            if(await _repo.UserExists(userForRegisterDto.UserName))
            {
                return BadRequest("Username is already taken"); 
            }

            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName
            };

            var createUser = await _repo.Register(userToCreate,userForRegisterDto.Password);

            return StatusCode(201);

        }
    }
}