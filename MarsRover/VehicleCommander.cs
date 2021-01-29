using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class VehicleCommander
    {
        private Dictionary<Vehicle, string> Vehicles { get; set; }

        public VehicleCommander()
        {
            Vehicles = new Dictionary<Vehicle, string>();
        }

        public void ExecuteCommand()
        {
            foreach (var item in Vehicles)
            {
                item.Key.Move(item.Value);
            }
        }

        public void Add(Vehicle vehicle, string movement)
        {
            Vehicles.Add(vehicle, movement);
        }

        public string GetAllVehiclesLastPositions()
        {
            return string.Join(Environment.NewLine, Vehicles.Select(x => x.Key));
        }
    }
}
