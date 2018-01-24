using System;
using System.Collections.Generic;
using System.Text;

namespace LearningTesting.DataModel
{
    public class Vehicle: ObjectBase
    {
        public Guid VechicleRegistration { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
    }
}
