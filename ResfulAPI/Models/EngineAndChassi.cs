using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class EngineAndChassi
    {
        public int? CarId { get; set; }
        public double? FuelTankCapacity { get; set; }
        public string? EngineType { get; set; }
        public string? NumberOfCylinder { get; set; }
        public double? CylinderCapacity { get; set; }
        public string? VariableValveSystem { get; set; }
        public string? FuelSystem { get; set; }
        public string? MaximumCapacity { get; set; }
        public string? MaximumTorque { get; set; }
        public string? Gear { get; set; }

        public virtual Car? Car { get; set; }
    }
}
