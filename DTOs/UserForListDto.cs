using System;

namespace DatingApp.API.DTOs
{
    public class UserForListDto
    {      
        public int Id {set;get;}
        public string UserName {set;get;}
         public string Gender {set;get;}
        public string KnownAs {set;get;}
        public int Age {set;get;}         
        public DateTime Created {set;get;}         
        public DateTime LastActive {set;get;}    
        public string City {set;get;}
        public string Country {set;get;}      
        public string PhotoUrl {set;get;}  
    }
}