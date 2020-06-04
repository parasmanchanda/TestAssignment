using AutoMapper;
using DataTransferObject.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.AutoMapper
{
    public class MappingProfille : Profile
    {
        public MappingProfille()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Resources, ResourceDTO>().ReverseMap();
            CreateMap<CountryCode, CountryCodeDTO>().ReverseMap();
        }
    }
}
