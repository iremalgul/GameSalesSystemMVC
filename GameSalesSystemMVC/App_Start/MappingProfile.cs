using AutoMapper;
using GameSalesSystemMVC.Dtos;
using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.App_Start
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, UserDto>().ReverseMap();
            Mapper.CreateMap<Cart, CartDto>().ReverseMap().ForMember(dest => dest.User, opt => opt.Ignore()); // Ignore circular reference;
            Mapper.CreateMap<CartGame, CartGameDto>().ReverseMap();
            Mapper.CreateMap<Game, GameDto>().ReverseMap();
            Mapper.CreateMap<Purchase, PurchaseDto>().ReverseMap();
            Mapper.CreateMap<PurchaseGame, PurchaseGameDto>().ReverseMap();
            Mapper.CreateMap<Review, ReviewDto>().ReverseMap();



        }
    }
}