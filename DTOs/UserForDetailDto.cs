using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.DTOs
{
    public class UserForDetailDto
    {
        public int Id {set;get;}
        public string UserName {set;get;}
        public string Gender {set;get;}
        public int Age {set;get;}      
        public string KnownAs {set;get;}
        public string City {set;get;}
        public string Country {set;get;}
        public string Introduction {set;get;}
        public string LookingFor {set;get;}
        public string Interest {set;get;}
     
        public DateTime Created {set;get;}         
         public DateTime LastActive {set;get;}        
         public string PhotoUrl {set;get;}
         public ICollection<PhotoForDetailDto> Photos {set;get;}
      
    }
}