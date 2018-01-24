using LearningTesting.DataModel;
using LearningTesting.IServices;
using LearningTesting.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Unity;

namespace LearningTesting.Test
{
    [TestClass]
    public class VehicleServiceTests
    {
        private IUnityContainer container;
        private IVehicleService vehicleService;
        private IDatabaseRepo dbRepo;
        [TestInitialize]
        public async Task Setup()
        {
            container = new UnityContainer();
            await Helpers.LearningTestingHelper.RegisterLearningTestingHelper(container);
            container.RegisterType<IVehicleService, VehicleService>();

            vehicleService = container.Resolve<IVehicleService>();
            dbRepo = container.Resolve<IDatabaseRepo>();
        }

        [TestMethod]
        public async Task VehicleService_AddVehicleTestAsync()
        {
            var vehicle = new Vehicle()
            {
                Id = Guid.NewGuid(),
                VechicleRegistration = Guid.NewGuid(),
                Brand = "FORD",
                Model = "FOCUS",
                Colour = "Black"
            };

            var resultMem = await dbRepo.Create<Vehicle>(vehicle);
            var resultSer = vehicleService.AddVehicle(vehicle);

            Assert.AreEqual(resultMem.VechicleRegistration, resultSer.VechicleRegistration);
        }

        [TestMethod]
        public async Task VehicleService_GetVehicleTestAsync()
        {
           
            var vehicle = new Vehicle()
            {
                Id = new Guid("8c9e6679-7425-40de-944b-e07fc1f90ae7"),
                VechicleRegistration = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                Brand = "FORD",
                Model = "FOCUS",
                Colour = "Black"
            };
           

            await dbRepo.Create<Vehicle>(vehicle);
          
            var resultMemGet = await dbRepo.Get<Vehicle>(vehicle.Id);
            var resultSer = vehicleService.GetVehicle(vehicle.VechicleRegistration);

            Assert.AreEqual(resultMemGet.VechicleRegistration, resultSer.VechicleRegistration);

        }

        [TestMethod]
        [Ignore]
        public void VehicleService_GetVehicleByColour()
        {

        }
    }
}
