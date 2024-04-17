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
        }
    }
}
