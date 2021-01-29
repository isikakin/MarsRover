using MarsRover.Enums;
using System;
using System.Linq;

namespace MarsRover
{
    static class Program
    {
        static void Main()
        {
            Console.Write("Enter max positions for rovers : ");
            var maxPositions = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            VehicleCommander commander = new VehicleCommander();

            Area area = new Area(maxPositions[0], maxPositions[1]);

            Console.Write("How many rover do you have? : ");
            int roverCount = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < roverCount; i++)
            {
                Console.Write("Enter start positions for MarsRover {0} : ", i + 1);
                var startPositions = Console.ReadLine().Trim().Split(' ');

                Rover r = new Rover(i + 1, int.Parse(startPositions[0]), int.Parse(startPositions[1]), (RoverDirection)Enum.Parse(typeof(RoverDirection), startPositions[2].ToString()), area);

                Console.Write("Enter moves for MarsRover {0} : ", i + 1);

                var moves = Console.ReadLine().ToUpper();

                commander.Add(r, moves);
            }
            commander.ExecuteCommand();
        }
    }
}
