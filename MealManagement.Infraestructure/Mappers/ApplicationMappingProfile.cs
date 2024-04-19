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
            CreateMap<Meal, MealEntity>().ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.MealId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.AvailableQuantity, opt => opt.MapFrom(src => src.AvailableQuantity))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.OrderDetails, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<User, UserEntity>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Order, OrderEntity>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails.Meals)).ReverseMap();

            CreateMap<OrderMeal, OrderDetailEntity>()
                        .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.MealId))
                        .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                        .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                        .ForMember(dest => dest.Meal, opt => opt.Ignore())
                        .ForMember(dest => dest.Order, opt => opt.Ignore())
                        .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal)).ReverseMap();
            ;


            CreateMap<OrderDetailEntity, OrderMeal>()
                .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.MealId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice)).ReverseMap();


            CreateMap<OrderDetailEntity, OrderDetails>()
                .ForMember(dest => dest.OrderDetailId, opt => opt.MapFrom(src => src.OrderDetailId)).ReverseMap();

            //CreateMap<OrderEntity, Order>()
            //    .ForMember(dest => dest.User.UserId, opt => opt.MapFrom(src => src.User.UserId))
            //    .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
            //    .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            //    .ForMember(dest => dest.User, opt => opt.Ignore());
                //.ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderDetailEntity, OrderDetails>()
                .ForMember(dest => dest.OrderDetailId, opt => opt.MapFrom(src => src.OrderDetailId));

            CreateMap<OrderDetailEntity, OrderMeal>()
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.MealId));

            // Mapeo de OrderEntity a Order
            CreateMap<OrderEntity, Order>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            // Configuración para mapear de List<OrderDetailEntity> a OrderDetails
            CreateMap<List<OrderDetailEntity>, OrderDetails>()
                .ConstructUsing(src => new OrderDetails { Meals = src.Select(detail => new OrderMeal(detail.MealId, detail.Quantity, detail.UnitPrice)).ToList() });

            // Mapeo de OrderDetailEntity a OrderMeal
            CreateMap<OrderDetailEntity, OrderMeal>()
                .ConstructUsing(src => new OrderMeal(src.MealId, src.Quantity, src.UnitPrice));

        }
    }
}
