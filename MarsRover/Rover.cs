using MarsRover.Enums;
using System;
using System.Threading;

namespace MarsRover
{
    public class Rover : Vehicle
    {
        public Rover(Area area)
        {
            this.X = 0;
            this.Y = 0;
            this.Direction = RoverDirection.N;
            this.Area = area;
        }

        public Rover(int name, int x, int y, RoverDirection roverDirection, Area area)
        {
            this.Name = name.ToString();
            this.X = x;
            this.Y = y;
            this.Direction = roverDirection;
            this.Area = area;
        }

        protected override void Move(MovementType movementType)
        {
            switch (movementType)
            {
                case MovementType.L:
                    Turn(movementType);
                    break;
                case MovementType.R:
                    Turn(movementType);
                    break;
                case MovementType.M:
                    Go();
                    break;
                default:
                    break;
            }
        }

        public override void Move(string movement)
        {
            Console.WriteLine();
            Console.Write($"{this.Name}.Rover is moving ");
            ConsoleUtility.WriteProgressBar(0);

            for (int i = 0; i <= movement.Length - 1; i++)
            {
                int progressbar = (i + 1) * 100 / movement.Length;

                Move((MovementType)Enum.Parse(typeof(MovementType), movement[i].ToString()));
                ConsoleUtility.WriteProgressBar(progressbar, true);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.WriteLine(this.ToString());
        }

        protected override void Go()
        {
            switch (Direction)
            {
                case RoverDirection.N:
                    Y++;
                    break;
                case RoverDirection.S:
                    Y--;
                    break;
                case RoverDirection.W:
                    X--;
                    break;
                case RoverDirection.E:
                    X++;
                    break;
                default:
                    break;
            }

            if (X < 0 || X > Area.MaxX || Y < 0 || Y > Area.MaxY)
            {
                throw new InvalidOperationException("Rover Position can not be bigger than max positions!");
            }
        }

        protected override void Turn(MovementType movementType)
        {
            switch (movementType)
            {
                case MovementType.L:
                    Direction = (RoverDirection)((4 + (int)Direction - 1) % 4);
                    break;
                case MovementType.R:
                    Direction = (RoverDirection)(((int)Direction + 1) % 4);
                    break;
                default:
                    break;
            }
        }
    }
}

