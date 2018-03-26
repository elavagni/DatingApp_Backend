using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Photo
    {
        public int Id {set;get;}
        public string Url{set;get;}
        public DateTime DateAdded {set;get;}
        public bool IsMainPhoto {set;get;}     

        public User User {set; get;}
        public int UserId {set;get;}  
    }
}