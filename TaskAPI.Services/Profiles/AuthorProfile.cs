using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;
using TaskAPI.Services.Models;

namespace TaskAPI.Services.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>().ForMember(dest => dest.Address,
            opt => opt.MapFrom(src => $"{src.AddressNo}, {src.Street}, {src.City}"));

            CreateMap<CreateAuthorDTO, Author>();
        }
    }
}
