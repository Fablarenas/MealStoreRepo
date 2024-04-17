using AutoMapper;
using MealManagement.Domain.DomainEntities;
using MealManagement.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagement.Infraestructure.Mappers
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<MealEntity, Meal>().ReverseMap();
            CreateMap<User, UserEntity>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                //.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))

                //.ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Username, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                //.ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
