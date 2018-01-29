using LearningTesting.DataModel;
using LearningTesting.IServices;
using LearningTesting.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace LearningTesting.Test
{
    [TestClass]
    public class VehicleServiceTests
    {
        private IUnityContainer container;
        private IVehicleService vehicleService;

        private IDatabaseRepo4Admin repo4Admin;

        [TestInitialize]
        public async Task Setup()
        {
            container = new UnityContainer();
            await Helpers.LearningTestingHelper.RegisterLearningTestingHelper(container);
            container.RegisterType<IVehicleService, VehicleService>();
            vehicleService = container.Resolve<IVehicleService>();
            repo4Admin = container.Resolve<IDatabaseRepo4Admin>();


            await repo4Admin.ClearRepo();
        }

        [TestMethod]
        public async Task VehicleService_AddVehicleAsync()
        {
            var dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle = new Vehicle()
            {
                Brand = "FORD",
                Model = "FOCUS",
                Colour = "Black"
            };

            var expected = await vehicleService.AddVehicle(vehicle);

            Assert.AreNotEqual(expected.Id, vehicle.Id);
            
        }

       

        [TestMethod]
        public async Task VehicleService_GetVehicleTestAsync()
        {
            var dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle = new Vehicle()
            {
                Brand = "FORD",
                Model = "FOCUS",
                Colour = "Black"
            };


            var actual = await dbRepo.Create<Vehicle>(vehicle);
            var expected = await vehicleService.GetVehicle(actual.Id);

            Assert.AreEqual(expected.Id, actual.Id);


        }

        [TestMethod]
        public async Task VehicleService_DeleteVehicle()
        {
            var dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle = new Vehicle()
            {
                Brand = "FORD",
                Model = "FOCUS",
                Colour = "Black"
            };
            var actual = await dbRepo.Create<Vehicle>(vehicle);
            var expected = await vehicleService.DeleteVehicle(actual.Id);
            Assert.IsTrue(expected);
        }


        [TestMethod]
        public async Task VehicleService_Update()
        {
            var dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle = new Vehicle()
            {
                Brand = "FORD",
                Model = "FOCUS",
                Colour = "Black"
            };

            var actual = await dbRepo.Create<Vehicle>(vehicle);
            vehicle.Colour = "Red";
            var expected = await vehicleService.UpdateVehicle(actual.Id, actual);

            Assert.AreNotEqual(expected.Colour, vehicle.Colour);
        }

        [TestMethod]
        public async Task VehicleService_GetVehicles()
        {
            var dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle1 = new Vehicle()
            {
                Brand = "FORD",
                Model = "FOCUS",
                Colour = "Black"
            };
            var vehicle2 = new Vehicle()
            {
                Brand = "MERCEDEZ",
                Model = "L",
                Colour = "Black"
            };

            var actual1 = await dbRepo.Create<Vehicle>(vehicle1);
            var actual2 = await dbRepo.Create<Vehicle>(vehicle2);

            var expected = await vehicleService.GetVehicles();

            Assert.IsTrue(expected.ToList().Any());
           

        }

        [TestMethod]
        public async Task VehicleService_DeleteVehicles()
        {
            var dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle1 = new Vehicle()
            {
                Brand = "FORD",
                Model = "FOCUS",
                Colour = "Black"
            };
            var vehicle2 = new Vehicle()
            {
                Brand = "MERCEDEZ",
                Model = "L",
                Colour = "Black"
            };

            var actual1 = await dbRepo.Create<Vehicle>(vehicle1);
            var actual2 = await dbRepo.Create<Vehicle>(vehicle2);

            var numVehicles = await vehicleService.DeleteVehicles();

            Assert.AreEqual(numVehicles, 2);
        }



    }
}
