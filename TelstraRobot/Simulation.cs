using System;

namespace TelstraRobot
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    };

    public class Simulation
    {
        private const int MaxGridSize = 5;

        public Robot Robot { get; set; }


        public bool Placed { get; set; }

        public Simulation()
        {
            Robot = new Robot();
        }

        public bool Place(int x, int y, Direction direction)
        {
            if (!CheckPositionValid(x, y)) return false;

            Robot.SetPlace(x, y, direction);
            Placed = true;
            return true;
        }

        public bool Move()
        {
            switch(Robot.Direction)
            {
                case Direction.NORTH:
                    return MakeMove(0, 1);
                case Direction.SOUTH:
                    return MakeMove(0, -1);
                case Direction.EAST:
                    return MakeMove(-1, 0);
                case Direction.WEST:
                    return MakeMove(1, 0);
                
            }

            return false;
        }

        public void Left()
        {
            if (Robot.Direction == Direction.NORTH)
                Robot.Direction = Direction.WEST;
            else
                Robot.Direction--;
        }

        public void Right()
        {
            if (Robot.Direction == Direction.WEST)
                Robot.Direction = Direction.NORTH;
            else
                Robot.Direction++;
        }

        public string Report()
        {
            return $"{Robot.X},{Robot.Y},{Enum.GetName(Robot.Direction)}";
        }


        private bool MakeMove(int xDir, int yDir)
        {
            if (!CheckPositionValid(Robot.X + xDir, Robot.Y + yDir)) 
                return false;

            Robot.X += xDir;
            Robot.Y += yDir;
            return true;
        }


        private bool CheckPositionValid(int x, int y)
        {
            return x >= 0 && y >= 0 && x <= MaxGridSize && y <= MaxGridSize;
        }
    }
}
