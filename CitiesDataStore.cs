using System;
using CityInfo.API.Models;

namespace CityInfo.API
{
	public class CitiesDataStore
	{
		public List<CityDto> Cities { get; set; }

		public CitiesDataStore()
		{
			Cities = new List<CityDto>()
			{
				new CityDto()
				{
					Id = 1,
					Name = "New York City",
					Description = "The one with that big park",
					PointsOfInterest = new List<PointOfInterestDto>()
					{
						new PointOfInterestDto()
						{
							Id  = 1,
							Name = "Central Park",
							Description = "The most visited urban park in US"
						},
                        new PointOfInterestDto()
                        {
                            Id  = 2,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscrapper located in midtown manhattan"
                        }
                    }
				},
				new CityDto()
				{
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the Cathedral that was never finished",
					PointsOfInterest = new List<PointOfInterestDto>()
					{
						new PointOfInterestDto()
						{
							Id = 3,
							Name = "Cathedral of our lady",
							Description = "A beautiful cathedral"
						},
                        new PointOfInterestDto()
                        {
                            Id  = 4,
                            Name = "Anthwerp central station",
                            Description = "The finest example of railway architecture in Belgium"
                        }
                    }
                },
				new CityDto()
				{
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower",
					PointsOfInterest = new List<PointOfInterestDto>()
					{
                        new PointOfInterestDto()
                        {
                            Id  = 5,
                            Name = "Eiffel tower",
                            Description = "The most visited tower in the world"
                        },
                        new PointOfInterestDto()
                        {
                            Id  = 6,
                            Name = "Louvre",
                            Description = "The world's largest museum"
                        }
                    }
                }
			};
		}
	}
}

