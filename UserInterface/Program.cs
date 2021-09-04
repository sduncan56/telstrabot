using System;
using TelstraRobot;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CommandParser();
            Console.WriteLine("Enter movement commands:");
            while (true)
            {
                string result = parser.ExecuteCommand(Console.ReadLine());
                if (!string.IsNullOrEmpty(result))
                    Console.WriteLine($"Output: {result}");
            }
        }
    }
}
