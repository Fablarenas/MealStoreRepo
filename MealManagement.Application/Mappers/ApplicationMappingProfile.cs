using AutoMapper;
using MealManagement.Application.Dtos;
using MealManagement.Domain.DomainEntities;

namespace MealManagement.Application.Mappers
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Meal, MealUpdateDto>()
            .ForMember(dest => dest.IdMeal, opt => opt.MapFrom(src => src.MealId))
            .ReverseMap(); 

            CreateMap<User, UserLoggedDto>().ReverseMap();
            CreateMap<MealDto, Meal>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.AvailableQuantity, opt => opt.MapFrom(src => src.AvailableQuantity))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();


            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderMeals));

            CreateMap<MealOrderDto[], OrderDetails>()
                .ForMember(dest => dest.Meals, opt => opt.MapFrom(src => src));

            CreateMap<MealOrderDto, OrderMeal>()
                .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.IdMeal))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.Ignore())  
                .AfterMap((src, dest) => {
                    
                });

            CreateMap<Order, OrderCreatedDto>()
                .ForMember(dest => dest.OrderID, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.orderCreatedDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderDetails, OrderCreatedDetailsDto>()
                .ForMember(dest => dest.MealsOrderCreated, opt => opt.MapFrom(src => src.Meals));

            CreateMap<OrderMeal, MealsOrderCreated>()
                .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.MealId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal));
        }
    }
}
