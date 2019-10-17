using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Model
{
    public class VehicleRepository :IvehicleRepository
    {
        private List<Vehicle> _vehiclelisyt;
        private readonly TodoContext _context;
        private readonly IServiceScope _scope;
        public VehicleRepository(IServiceProvider service)
        {
            _scope = service.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<TodoContext>();
        }

        public List<Vehicle> GetAllVehicle()
        {
           var result= _context.Vehicles.OrderByDescending(x=>x.id);
            return result.ToList();
        }

        public Vehicle GetVehicle(long id)
        {
            var result = _context.Vehicles.Where(x => x.id == id).FirstOrDefault();
            return result;
        }

        public async Task<bool> Update(Vehicle vehicle)
        {
            var success = false;
            var ExistingVehicle = GetVehicle(vehicle.id);
            if(ExistingVehicle!=null)
            {
                ExistingVehicle.Make = vehicle.Make;
                ExistingVehicle.Model = vehicle.Model;
                ExistingVehicle.Engine = vehicle.Engine;
                ExistingVehicle.BodyType = vehicle.BodyType;
                _context.Vehicles.Attach(ExistingVehicle);
                var numberOfItemUpdated = await _context.SaveChangesAsync();
                if(numberOfItemUpdated==1)
                {
                    success = true;
                }
            }
            return success;
        }

        public async Task<bool> Create(Vehicle vehicle)
        {
            var success = false;
            _context.Vehicles.Add(vehicle);
            var numberOfItemsCreated = await _context.SaveChangesAsync();
            if (numberOfItemsCreated == 1)
                success = true;

            return success;
        }

        public async Task<bool> Delete(long id)
        {
            var success = false;

            var existingVehicle = GetVehicle(id);

            if (existingVehicle != null)
            {
                _context.Vehicles.Remove(existingVehicle);

                var numberOfItemsDeleted = await _context.SaveChangesAsync();

                if (numberOfItemsDeleted == 1)
                    success = true;
            }

            return success;
        }
    }
}
