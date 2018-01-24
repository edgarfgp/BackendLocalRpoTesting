using LearningTesting.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningTesting.IServices
{
    public interface IVehicleService
    {
        Vehicle GetVehicle(Guid vehicleRegistration);
        IEnumerable<Vehicle> GetVehicleByColour(string colour);
        Vehicle AddVehicle(Vehicle v);
    }
}
