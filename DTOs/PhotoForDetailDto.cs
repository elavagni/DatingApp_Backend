using System;

namespace DatingApp.API.DTOs
{
    public class PhotoForDetailDto
    {
        public int Id {set;get;}
        public string Url{set;get;}
        public DateTime DateAdded {set;get;}
        public bool IsMainPhoto {set;get;}     
    }
}