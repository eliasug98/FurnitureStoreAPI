﻿using AutoMapper;

namespace FurnitureStore.API.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, DTOs.UserDTOs.UsersDto>();
            CreateMap<Entities.User, DTOs.UserDTOs.UserDto>();
            CreateMap<DTOs.UserDTOs.UserToCreateDto, Entities.User>();
            CreateMap<DTOs.UserDTOs.UserToUpdateDto, Entities.User>();
        }
    }
}
