using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.DTOs
{
    public class PhotoForCreationDto
    {
        public string Url {set;get;}
        public IFormFile File {set;get;}

        public string Description {set;get;}
        public DateTime DateAdded {set;get;}
        
        public string PublicId {set;get;}

        public PhotoForCreationDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}