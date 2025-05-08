using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, FriendDto>();
            CreateMap<FriendRequest, ReceivedFriendRequestDto>()
                .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FromUsername, opt => opt.MapFrom(src => src.FromUser.Username))
                .ForMember(dest => dest.FromUserId, opt => opt.MapFrom(src => src.FromUserId))
                .ForMember(dest => dest.FromProfilePictureUrl, opt => opt.MapFrom(src => src.FromUser.ProfilePictureUrl))
                .ForMember(dest => dest.SentAt, opt => opt.MapFrom(src => src.SentAt));
            CreateMap<User, UserInfoDto>();
            CreateMap<User, MeDto>();
        }
    }
}
