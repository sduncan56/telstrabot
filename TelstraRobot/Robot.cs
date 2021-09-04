using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelstraRobot
{
    public class Robot
    {
        public Direction Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as Robot);

        public bool Equals(Robot r)
        {
            if (r == null)
                return false;

            return X == r.X && Y == r.Y && Direction == r.Direction;
        }

        public void SetPlace(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
