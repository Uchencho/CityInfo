using System;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
	public class PointOfInterestForCreationDto
	{
		public PointOfInterestForCreationDto()
		{
		}

		[Required(ErrorMessage = "You should provide a name value")]
		[MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200, ErrorMessage = "Maximum length is 50, boss")]
        public string? Description { get; set; }
    }
}

