using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using WEBApplikation.Data.Migrations;
using WEBApplikation.Models;

namespace WEBApplikation.DAL
{
    public class GardenerRepository
    {
        private DbContextOptions<GardenerDbContext> _context;

        public GardenerRepository()
        {
            _context = new DbContextOptionsBuilder<GardenerDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EksamenGUIDatabase;Trusted_Connection=true;MultipleActiveResultSets=true")
                .Options;
        }

        public bool CreateDatabase()
        {
            using (var database = new GardenerDbContext(_context))
            {
                if (true && (database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return false;

                database.Database.EnsureDeleted();
                return database.Database.EnsureCreated();
            }
        }

        #region Creations

        public async Task AddSensor(Sensor sensor)
        {
            using (var database = new GardenerDbContext(_context))
            {
                await database.Sensors.AddAsync(sensor);
                await database.SaveChangesAsync();
            }
        }

        #endregion

        #region Lists

        public async Task<IEnumerable<Location>> GetLocations()
        {
            using (var database = new GardenerDbContext(_context))
            {
                var locations = await database.Locations.ToListAsync();
                return locations;
            }
        }

        public async Task<IEnumerable<Sensor>> GetSensorsByLocation(int id)
        {
            using (var database = new GardenerDbContext(_context))
            {
                var sensors = await database.Sensors.Where(s => s.LocationId == id).ToListAsync();
                return sensors;
            }
        }

        public async Task<IEnumerable<Sensor>> GetSensors()
        {
            using (var database = new GardenerDbContext(_context))
            {
                var sensors = await database.Sensors.ToListAsync();
                return sensors;
            }
        }

        public async Task<IEnumerable<Tree>> GetTreesByLocation(int id)
        {
            using (var database = new GardenerDbContext(_context))
            {
                var trees = await database.Trees.Where(t => t.LocationId == id).ToListAsync();
                return trees;
            }
        }



        #endregion

        public async Task<Location> GetLocationById(int id)
        {
            using (var database = new GardenerDbContext(_context))
            {
                var location = database.Locations.FindAsync(id).Result;
                return location;
            }
        }
    }
}
