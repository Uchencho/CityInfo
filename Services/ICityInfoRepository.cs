﻿using System;
using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
	public interface ICityInfoRepository
	{
		Task<IEnumerable<City>> GetCitiesAsync();
        Task<(IEnumerable<City>, PaginationMetadata)> GetCitiesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
		Task<City?> GetCityAsync(int cityId, bool includePointOfInterest);
		Task<IEnumerable<PointOfInterest>> GetPointsOfInterestAsync(int cityId);
		Task<bool> CityExistsAsync(int cityId);
		Task<PointOfInterest?> GetPointOfInterestAsync(int cityId, int pointOfInterestId);
		Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
		void DeletePointOfInterest(PointOfInterest poi);
		Task<bool> SaveChangesAsync();
	}
}
