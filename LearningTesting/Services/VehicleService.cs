using LearningTesting.DataModel;
using LearningTesting.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningTesting.Services
{
    public class VehicleService : IVehicleService
    {
        IEnumerable<Vehicle> listVehicles = new List<Vehicle>
        {
            new Vehicle()
            {
                VechicleRegistration=Guid.NewGuid(),
                Brand="BMW",
                Model="320D",
                Colour="Black"
            },
            new Vehicle()
            {
                VechicleRegistration=Guid.NewGuid(),
                Brand="AUDI",
                Model="A3",
                Colour="White"
            },
            new Vehicle()
            {
                VechicleRegistration=Guid.NewGuid(),
                Brand="MERCEDES BENZ",
                Model="CLA",
                Colour="Black"
            },
            new Vehicle()
            {
                VechicleRegistration=Guid.NewGuid(),
                Brand="VOLKSWAGEN",
                Model="GOLF GTI",
                Colour="White"
            },
        };

        public Vehicle AddVehicle(Vehicle v)
        {
            listVehicles.ToList().Add(v);
            return v;
        }
          
        public Vehicle GetVehicle(Guid id)
        {
            return listVehicles.Where(v => v.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Vehicle> GetVehicleByColour(string colour)
        {
            return listVehicles.Where(v => v.Colour.Equals(colour));
        }
    }
}
