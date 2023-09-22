using System;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DBContexts
{
	public class CityInfoContext : DbContext
	{
		public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
		{
		}

		public DbSet<City> Cities { get; set; } = null!;
		public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("New York City")
                    {
                        Id = 1,
                        Description = "The one with that big park",
                    },
                new City("Antwerp")
                    {
                        Id = 2,
                        Description = "The one with the Cathedral that was never finished",
                    },
                new City("Paris")
                    {
                        Id = 3,
                        Description = "The one with that big tower",
                    }
                );

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("Central Park")
                    {
                        Id = 1,
                        CityId = 1,
                        Description = "The most visited urban park in US",
                    },
                new PointOfInterest("Empire State Building")
                    {
                        Id = 2,
                        CityId = 1,
                        Description = "A 102-story skyscrapper located in midtown manhattan",
                    },
                new PointOfInterest("Cathedral of our lady")
                    {
                        Id = 3,
                        CityId = 2,
                        Description = "A beautiful cathedral",
                    },
                new PointOfInterest("Anthwerp central station")
                    {
                        Id = 4,
                        CityId = 2,
                        Description = "The finest example of railway architecture in Belgium",
                    },
                new PointOfInterest("Eiffel tower")
                    {
                        Id = 5,
                        CityId = 3,
                        Description = "The most visited tower in the world",
                    },
                new PointOfInterest("Louvre")
                {
                    Id = 6,
                    CityId = 3,
                    Description = "The world's largest museum",
                }
                );
            base.OnModelCreating(modelBuilder);
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //   optionsBuilder.UseSqlite("connectionString");
        //   base.OnConfiguring(optionsBuilder);
        // }
    }
}

