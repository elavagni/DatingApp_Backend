using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace DatingApp.API.Models {
    public class User : IdentityUser<int> 
    {
        public string KnownAs { set; get; }
        public string Gender { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
        public string Introduction { set; get; }
        public string LookingFor { set; get; }
        public string Interest { set; get; }
        public DateTime DateOfBirthDay { set; get; }
        public DateTime Created { set; get; }
        public DateTime LastActive { set; get; }

        public virtual ICollection<Photo> Photos { set; get; }
        public virtual ICollection<Like> LikesGiven { set; get; }
        public virtual ICollection<Like> LikesReceived { set; get; }
        public virtual ICollection<Message> MessageSent { set; get; }
        public virtual ICollection<Message> MessageReceived { set; get; }
        public virtual ICollection<UserRole> UserRoles { set; get; }

        public User () => Photos = new Collection<Photo> ();
    }
}