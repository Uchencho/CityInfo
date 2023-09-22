using System;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[ApiController]
	[Route("api/cities")]
	public class CitiesController : ControllerBase
	{
        private readonly CitiesDataStore _cityDataStore;

        public CitiesController(CitiesDataStore cityDataStore)
		{
            _cityDataStore = cityDataStore ?? throw new ArgumentNullException(nameof(cityDataStore));
        }

		[HttpGet]
		public JsonResult GetCities()
		{
			return new JsonResult(_cityDataStore.Cities) ;
		}
		[HttpGet("{id}")]
		public JsonResult GetCity(int id)
		{
			var val = _cityDataStore.Cities.FirstOrDefault(c => c.Id == id);
			if (val == null)
			{
				Console.WriteLine($"value of val is {val}");
				return new JsonResult(new object());
			}
            Console.WriteLine($"value of val is {val}");

            return new JsonResult(val);
		}
	}
}
