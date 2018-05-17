using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName {set;get;}

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]        
         public string Password {set;get;}

        [Required]
        public string Gender {set;get;}

        [Required]
        public string KnownAs {set;get;}

        [Required]
        public string City {set;get;}

        [Required]
        public string Country {set;get;}

        [Required]
        public DateTime DateOfBirthDay {set;get;}

        public DateTime Created {set;get;}

        public DateTime LastActive {set;get;}



        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}