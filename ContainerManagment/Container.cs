using System;
using System.Collections.Generic;

namespace ContainerManagment
{

    public class Container
    {
        private static int _serialNumberCounter = 1;
        private static HashSet<string> _existingSerialNumber = new HashSet<string>();
        
        public double CargoMassKg { get; set; }
        public double HeighCm { get; set; }
        public double TareWeightKg { get; set; }
        public double DepthCm { get; set; }
        public string SerialNumber { get; private set; }
        public double MaxLoadCapacityKg { get; set; }

        public Container(string ContainerType)
        {
            SerialNumber = GenerateUniqueSerialNumber(containerType);

        }

        private string GenerateUniqueSerialNumber(string ContainerType)
        {
            string serialNumber;
            do
            {
                serialNumber = $"KON-{ContainerType}-{_serialNumberCounter++}";
            } while (_existingSerialNumber.Contains(serialNumber));
            
            _existingSerialNumber.Add(serialNumber);
            return serialNumber;
        }
        
        public void LoadCargo(double cargoMassKg)
        {
            if (CargoMassKg + cargoMassKg > MaxLoadCapacityKg)
            {
                throw new InvalidOperationException("Cargo mass exceeds max load capacity");
            }
            CargoMassKg += cargoMassKg;
        }

        public void UnloadCargo()
        {
            CargoMassKg = 0;
        }

    }
}