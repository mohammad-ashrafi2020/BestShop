using Account.Application.Models.DTOs.Account;
using Account.Application.Models.DTOs.Addresses;
using Account.Application.Models.DTOs.Cards;
using Account.Application.Models.DTOs.Notifications;
using Account.Application.Models.DTOs.Wallets;
using Account.Domain.Entities.Users;
using AutoMapper;

namespace Account.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();

           
            CreateMap<UserWallet, WalletDto>().ReverseMap();
            CreateMap<UserAddress, InsertAddressDto>().ReverseMap();
            CreateMap<UserAddress, EditAddressDto>().ReverseMap();
            CreateMap<InsertCardDto, UserCard>().ReverseMap();

        }
    }
}