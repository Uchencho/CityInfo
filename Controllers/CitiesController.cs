using System;
using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[ApiController]
	[Route("api/cities")]
	public class CitiesController : ControllerBase
	{
        //private readonly CitiesDataStore _cityDataStore;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
		{
            //_cityDataStore = cityDataStore ?? throw new ArgumentNullException(nameof(cityDataStore));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCitiesAsync()
		{
			var cityEntities = await _cityInfoRepository.GetCitiesAsync();
			return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
			//var result = new List<CityWithoutPointsOfInterestDto>();

			//foreach(City c in cityEntities)
			//{
			//	result.Add(new CityWithoutPointsOfInterestDto
			//	{
			//		Id = c.Id,
			//		Description = c.Description,
			//		Name = c.Name,
			//	});
			//}
			//return Ok(result);
			//return Ok()
			//return new JsonResult(_cityDataStore.Cities);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCity(int id, bool includePointOfInterest = false)
		{
			//var val = _cityDataStore.Cities.FirstOrDefault(c => c.Id == id);
			//if (val == null)
			//{
			//	Console.WriteLine($"value of val is {val}");
			//	return new JsonResult(new object());
			//}
			//  Console.WriteLine($"value of val is {val}");

			var city = await _cityInfoRepository.GetCityAsync(id, includePointOfInterest);
			if (city == null)
			{
				return NotFound();
			}

			if (includePointOfInterest)
			{
				return Ok(_mapper.Map<CityDto>(city));
			}
            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
		}
	}
}
