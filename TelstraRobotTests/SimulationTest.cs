using System;
using TelstraRobot;
using Xunit;

namespace TelstraRobotTests
{
    public class SimulationTest
    {
        [Theory]
        [InlineData(0, 0, Direction.NORTH)]
        public void PlaceInValidPosition(int x, int y, Direction direction)
        {
            var robot = new Robot() { X = x, Y = y, Direction = direction };

            Simulation simulation = new Simulation();
            bool placed = simulation.Place(x, y, direction);
            Assert.True(placed);
            Assert.Equal(robot, simulation.Robot);
        }

        [Theory]
        [InlineData(-1, 0, Direction.WEST)]
        [InlineData(0, -1, Direction.WEST)]
        [InlineData(6, 3, Direction.WEST)]
        [InlineData(3, 6, Direction.WEST)]
        public void PlaceInInvalidPosition(int x, int y, Direction direction)
        {
            Simulation simulation = new Simulation();
            bool placed = simulation.Place(x, y, direction);
            Assert.False(placed);

        }

        [Theory]
        [InlineData(2, 3, Direction.NORTH)]
        [InlineData(2, 1, Direction.SOUTH)]
        [InlineData(1, 2, Direction.WEST)]
        [InlineData(3, 2, Direction.EAST)]

        public void MakeValidMove(int x, int y, Direction direction)
        {
            var expected = new Robot() { X = x, Y = y, Direction = direction };
            Simulation simulation = new Simulation();
            simulation.Place(2, 2, direction);
            simulation.Move();
            Assert.Equal(expected, simulation.Robot);

        }

        [Theory]
        [InlineData(2, 5, Direction.NORTH)]
        [InlineData(2, 0, Direction.SOUTH)]
        [InlineData(0, 2, Direction.WEST)]
        [InlineData(5, 2, Direction.EAST)]
        public void MakeInvalidMove(int x, int y, Direction direction)
        {
            var expected = new Robot() { X = x, Y = y, Direction = direction };

            Simulation simulation = new Simulation();
            simulation.Place(x, y, direction);
            bool moved = simulation.Move();
            Assert.False(moved);
            Assert.Equal(expected, simulation.Robot);
        }

        [Fact]
        public void TurnsLeft()
        {
            Simulation simulation = new Simulation();
            simulation.Place(2, 2, Direction.NORTH);
            simulation.Left();
            Assert.Equal(Direction.WEST, simulation.Robot.Direction);
            simulation.Left();
            Assert.Equal(Direction.SOUTH, simulation.Robot.Direction);
            simulation.Left();
            Assert.Equal(Direction.EAST, simulation.Robot.Direction);
            simulation.Left();
            Assert.Equal(Direction.NORTH, simulation.Robot.Direction);

        }

        [Fact]
        public void TurnsRight()
        {
            Simulation simulation = new Simulation();
            simulation.Place(2, 2, Direction.NORTH);
            simulation.Right();
            Assert.Equal(Direction.EAST, simulation.Robot.Direction);
            simulation.Right();
            Assert.Equal(Direction.SOUTH, simulation.Robot.Direction);
            simulation.Right();
            Assert.Equal(Direction.WEST, simulation.Robot.Direction);
            simulation.Right();
            Assert.Equal(Direction.NORTH, simulation.Robot.Direction);


        }

        [Fact]
        public void ReportsPosition()
        {
            Simulation simulation = new Simulation();
            simulation.Place(2, 2, Direction.NORTH);

            string result = simulation.Report();
            Assert.Equal("2,2,NORTH", result);
        }


    }
}
