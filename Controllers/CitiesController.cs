﻿using System.Text.Json;
using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
	//[Authorize
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/cities")]
	public class CitiesController : ControllerBase
	{
        //private readonly CitiesDataStore _cityDataStore;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
		const int maxCitiesPageSize = 20;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
		{
            //_cityDataStore = cityDataStore ?? throw new ArgumentNullException(nameof(cityDataStore));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCitiesAsync([FromQuery(Name = "q")] string? name,
			string? searchQuery, int pageNumber = 1, int pageSize = 10)
		{
			if (pageSize > maxCitiesPageSize)
			{
				pageSize = maxCitiesPageSize;
			}

			var (cityEntities,pagination) = await _cityInfoRepository.GetCitiesAsync(name, searchQuery, pageNumber, pageSize);
			Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
			
			return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCity(int id, bool includePointOfInterest = false)
		{
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
