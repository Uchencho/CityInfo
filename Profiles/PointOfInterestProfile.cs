using System;
using AutoMapper;

namespace CityInfo.API.Profiles
{
	public class PointOfInterestProfile : Profile
	{
		public PointOfInterestProfile()
		{
            CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
			CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>();
			CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>(); // source to destination
			CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
        }
	}
}

