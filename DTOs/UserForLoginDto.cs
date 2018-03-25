using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserForLoginDto
    {       
         [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a username between 4 and 8 characters")]        
        public string UserName {set;get;}
      
       [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]        
        public string Password {set;get;}
    }
}