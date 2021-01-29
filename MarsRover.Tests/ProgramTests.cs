using MarsRover.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRover.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        const string expected = "1.Rover: 1 - 3 - N";
        const string expected2 = "2.Rover: 5 - 1 - E";
        const string expected3 = "1.Rover: 1 - 3 - N\r\n2.Rover: 5 - 1 - E";

        [DataTestMethod]
        [DataRow(1, 1, 2, RoverDirection.N, "LMLMLMLMM", expected)]
        [DataRow(2, 3, 3, RoverDirection.E, "MMRMMRMRRM", expected2)]
        public void Scenerio1(int roverName, int x, int y, RoverDirection startPosition, string movements, string expected)
        {
            Area area = new Area(5, 5);

            Rover rover = new Rover(roverName, x, y, startPosition, area);
            VehicleCommander commander = new VehicleCommander();

            commander.Add(rover, movements);
            commander.ExecuteCommand();
            Assert.AreEqual(expected, commander.GetAllVehiclesLastPositions());
        }

        [TestMethod()]
        public void Scenerio2()
        {
            Area area = new Area(5, 5);
            Rover rover1 = new Rover(1, 1, 2, RoverDirection.N, area);
            Rover rover2 = new Rover(2, 3, 3, RoverDirection.E, area);

            VehicleCommander commander = new VehicleCommander();
            commander.Add(rover1, "LMLMLMLMM");
            commander.Add(rover2, "MMRMMRMRRM");
            commander.ExecuteCommand();

            Assert.AreEqual(expected3, commander.GetAllVehiclesLastPositions());
        }

        [TestMethod()]
        public void FailScenerio1()
        {
            Area area = new Area(5, 5);
            Rover rover = new Rover(2, 3, 3, RoverDirection.E, area);

            VehicleCommander commander = new VehicleCommander();
            commander.Add(rover, "MMMMMMMMMMMMMMMMMMMMMMMMMMMM");
            Assert.ThrowsException<InvalidOperationException>(() => commander.ExecuteCommand());
        }
    }
}