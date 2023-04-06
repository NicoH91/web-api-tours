using AutoMapper;
using WebApiTours.DTOs;
using WebApiTours.Entity;

namespace WebApiTours.Utility
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TourCreationDTO, Tour>();
            CreateMap<Tour, TourDTO>();

            CreateMap<GuestCreationDTO, Guest>();
            CreateMap<Guest, GuestDTO>();

            CreateMap<DetailCreationDTO, Detail>();
            CreateMap<Detail, DetailDTO>();

            CreateMap<ChallengeCreationDTO, Challenge>();
            CreateMap<Challenge, ChallengeDTO>();
        }
    }
}
