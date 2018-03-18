using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserForLoginDto
    {       
        public string UserName {set;get;}
      
        public string Password {set;get;}
    }
}