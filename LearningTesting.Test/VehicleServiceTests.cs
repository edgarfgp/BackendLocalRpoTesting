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

        [TestInitialize]
        public async Task Setup()
        {
            container = new UnityContainer();
            
            await Helpers.LearningTestingHelper.RegisterLearningTestingHelper(container);

            container.RegisterType<IVehicleService, VehicleService>();

            vehicleService = container.Resolve<IVehicleService>();
        }

        [TestMethod]
        public async Task VehicleService_AddVehicleTestAsync()
        {
            IDatabaseRepo dbRepo = container.Resolve<IDatabaseRepo>();

            var vehicle = new Vehicle()
            {
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
            IDatabaseRepo dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle = new Vehicle()
            {
                VechicleRegistration = Guid.NewGuid(),
                Brand = "FORD",
                Model = "FOCUS",
                Colour = "Black"
            };

            var resultMem_Create = await dbRepo.Create<Vehicle>(vehicle);
            var resultSer_Create = vehicleService.AddVehicle(vehicle);

            
            var resultMem_Get = await dbRepo.Get<Vehicle>(resultMem_Create.VechicleRegistration);
            var resultSer_Get = vehicleService.GetVehicle(resultSer_Create.VechicleRegistration);

            Assert.AreEqual(resultMem_Get.VechicleRegistration, resultSer_Get.VechicleRegistration);
        }

        [TestMethod]
        [Ignore]
        public void VehicleService_GetVehicleByColour()
        {

        }
    }
}
