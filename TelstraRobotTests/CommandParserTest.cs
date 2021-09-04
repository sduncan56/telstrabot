using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstraRobot;
using Xunit;

namespace TelstraRobotTests
{
    public class CommandParserTest
    {
        [Theory]
        [InlineData(new string[] { "PLACE 0,0,NORTH", "MOVE" }, "0,1,NORTH")]
        [InlineData(new string[] { "PLACE 0,0,NORTH", "LEFT" }, "0,0,WEST")]
        [InlineData(new string[] { "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE" }, "3,3,NORTH")]
        [InlineData(new string[] { "PLACE 1,2,EAST", "MOVE", "LEFT", "MOVE", "PLACE 3,1", "MOVE" }, "3,2,NORTH")]
        public void TestParser(string[] commands, string expected)
        {
            CommandParser parser = new CommandParser();
            foreach (var command in commands)
            {
                parser.ExecuteCommand(command);
            }
            var result = parser.ExecuteCommand("REPORT");
            Assert.Equal(expected, result);

        }
    }
}
