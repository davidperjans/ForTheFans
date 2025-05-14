using Application.Common.Responses;
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
    public class StadiumProfile : Profile
    {
        public StadiumProfile()
        {

            CreateMap<Stadium, StadiumDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.Surface, opt => opt.MapFrom(src => src.Surface))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<StadiumApiResponse.ResponseStadium, StadiumDto>()
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src =>
                    src.Capacity > 0 ? src.Capacity : 0)) // Sätt till 0 om Capacity är ogiltigt
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Surface, opt => opt.MapFrom(src => src.Surface))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image));

        }
    }
}
