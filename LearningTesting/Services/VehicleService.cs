using LearningTesting.DataModel;
using LearningTesting.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTesting.Services
{
    
    public class VehicleService : IVehicleService
    {
        private IDatabaseRepo databaseRepo;
        private IDatabaseRepo4Admin repo4Admin;

        public VehicleService(IDatabaseRepo databaseRepo, IDatabaseRepo4Admin repo4Admin)
        {
            this.databaseRepo = databaseRepo;
            this.repo4Admin = repo4Admin;
        }

       
        async Task<IEnumerable<Vehicle>> IVehicleService.GetVehicles()
        {
            return await databaseRepo.Get<Vehicle>();
        }

        async Task<int> IVehicleService.DeleteVehicles()
        {
            return await databaseRepo.DeleteAll<Vehicle>();
        }

        async Task<Vehicle> IVehicleService.AddVehicle(Vehicle v)
        {
            return await databaseRepo.Create<Vehicle>(v);
        }

        async Task<Vehicle> IVehicleService.UpdateVehicle(Guid id, Vehicle v)
        {
            return await databaseRepo.Update<Vehicle>(id, v);
        }

        async Task<Vehicle> IVehicleService.GetVehicle(Guid id)
        {
            return await databaseRepo.Get<Vehicle>(id);
        }

        async Task<bool> IVehicleService.DeleteVehicle(Guid id)
        {
            return await databaseRepo.Delete<Vehicle>(id);
        }

    }
}
