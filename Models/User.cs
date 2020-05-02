using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DatingApp.API.Models
{
    public class User
    {
        public int Id {set;get;}
        public string UserName {set;get;}
        public byte[] PasswordHash {set;get;}
        public byte[] PasswordSalt {set;get;}

        public string KnownAs {set;get;}
        public string Gender {set;get;}
        public string City {set;get;}
        public string Country {set;get;}
        public string Introduction {set;get;}
        public string LookingFor {set;get;}
        public string Interest {set;get;}
        public DateTime DateOfBirthDay {set;get;}
        public DateTime Created {set;get;}         
        public DateTime LastActive {set;get;}

        
        public virtual ICollection<Photo> Photos {set;get;}
        public virtual ICollection<Like> LikesGiven {set;get;}
        public virtual ICollection<Like> LikesReceived {set;get;}
        public virtual ICollection<Message> MessageSent {set;get;}
        public virtual ICollection<Message> MessageReceived {set;get;}

        public User() => Photos = new Collection<Photo>();
    }
}