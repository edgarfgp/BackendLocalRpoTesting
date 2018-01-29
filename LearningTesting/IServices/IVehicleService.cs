using LearningTesting.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningTesting.IServices
{
    public interface IVehicleService
    {
        Task<Vehicle> AddVehicle(Vehicle v);
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<Vehicle> GetVehicle(Guid id);
        Task<bool> DeleteVehicle(Guid id);
        Task<int> DeleteVehicles();
        Task<Vehicle> UpdateVehicle(Guid id, Vehicle v);




    }
}
