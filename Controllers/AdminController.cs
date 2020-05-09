using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]   
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        public AdminController(DataContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Policy = "RequiredAdminRole")]
        [HttpGet("usersWithRoles")]
        public async Task<IActionResult> GetUsersWithRoles() 
        {
            var userList = await _context.Users
                .OrderBy(x => x.UserName)
                .Select(user => new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = (from userRole in user.UserRoles
                            join role in _context.Roles
                            on userRole.RoleId 
                            equals role.Id
                            select role.Name).ToList()
                }).ToListAsync();                             
            
            return Ok(userList);
        }

        [Authorize(Policy = "RequiredAdminRole")]
        [HttpPost("editRoles/{userName}")]
        public async Task<IActionResult> EditRoles(string userName, RoleEditDto roleEditDto) 
        {
            var user = await _userManager.FindByNameAsync(userName);

            var userRoles = await _userManager.GetRolesAsync(user);

            var selecedRoles = roleEditDto.RoleNames;

            selecedRoles = selecedRoles ?? new string[] {};
            
            //Add selected rolesd
            var result =  await _userManager.AddToRolesAsync(user, selecedRoles.Except(userRoles));

            if(!result.Succeeded) 
                return BadRequest("Failed to add to roles");

            //remove unselected roles
            result =  await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selecedRoles));

            if(!result.Succeeded) 
                return BadRequest("Failed to remove the roles");

             return Ok(await _userManager.GetRolesAsync(user));
        }
        
        
        
        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("photosForModeration")]
        public IActionResult GetPhotosForModeration() 
        {
            return Ok("Admins and moderators can see this");
        }
    }
}