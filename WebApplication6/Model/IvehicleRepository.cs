using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Model
{
   public interface IvehicleRepository
    {
        List<Vehicle> GetAllVehicle();

        Vehicle GetVehicle(long id);

        Task<bool> Update(Vehicle vehicle);
        Task<bool> Create(Vehicle vehicle);
        Task<bool> Delete(long id);
    }
}
