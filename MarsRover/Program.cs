using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- INPUTS ----- ");
            //Get plateu boundaries
            string plateuBoundaries = Console.ReadLine();

            //Get First rover's instruction information and execution commands
            string firstRoverInstructions = Console.ReadLine();
            string firstRoverCommands = Console.ReadLine();

            //Get Second rover's instruction information and execution commands
            string secondRoverInstructions = Console.ReadLine();
            string secondRoverCommands = Console.ReadLine();


            Console.WriteLine("----- OUTPUTS -----");
            //Create Plateu boundaries
            Plateu plateu = new Plateu(plateuBoundaries);

            //Instantiate First Rover, Execute commands
            Rover firstRover = new Rover(firstRoverInstructions, plateu);
            firstRover.ExecuteCommands(firstRoverCommands.ToCharArray().ToList());
            firstRover.PrintRoverCurrentState();

            //Instantiate Second Rover, Execute commands
            Rover secondRover = new Rover(secondRoverInstructions, plateu);
            secondRover.ExecuteCommands(secondRoverCommands.ToCharArray().ToList());
            secondRover.PrintRoverCurrentState();

            Console.ReadKey();
        }
    }
}
