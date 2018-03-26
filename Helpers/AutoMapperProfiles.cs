using System.Linq;
using AutoMapper;
using DatingApp.API.DTOs;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMainPhoto).Url);
                })
                 .ForMember(dest => dest.Age, opt => 
                {
                    opt.ResolveUsing(d => d.DateOfBirthDay.CalculateAge());
                });

            CreateMap<User,UserForDetailDto>();
            
            CreateMap<Photo,PhotoForDetailDto>();
        }
        
    }
}