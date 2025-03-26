using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationD.Core.DTOs;
using VacationD.Core.Entities;

namespace VacationD.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap <User, UserDto>().ReverseMap();
            CreateMap <Vacation, VacationDto>().ReverseMap();
        }
    }
}
