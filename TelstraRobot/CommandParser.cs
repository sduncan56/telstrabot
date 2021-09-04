using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelstraRobot
{
    public class CommandParser
    {
        private Simulation _simulation = new Simulation();

        public string ExecuteCommand(string command)
        {
            if (command.StartsWith("PLACE"))
            {
                string dataString = command.Substring(5);
                var data = dataString.Split(",");

                int x = Int32.Parse(data[0]);
                int y = Int32.Parse(data[1]);
                var direction = (Direction)Enum.Parse(typeof(Direction), data[2]);

                _simulation.Place(x, y, direction);
            }
           
            if (!_simulation.Placed) return string.Empty;

            switch(command)
            {
                case "MOVE":
                    _simulation.Move();
                    break;
                case "LEFT":
                    _simulation.Left();
                    break;
                case "RIGHT":
                    _simulation.Right();
                    break;
                case "REPORT":
                    return _simulation.Report();
            }

            return string.Empty;

        }
    }
}
