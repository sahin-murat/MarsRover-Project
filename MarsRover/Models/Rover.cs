using System;
using System.Collections.Generic;

namespace MarsRover.Models
{
    public class Rover
    {
        private int _positionX;
        private int _positionY;
        private string _direction;
        private Plateu _plateu;

        /// <summary>
        /// Initialize rover by setup instructions and it's plateu bounderies to explore
        /// <para>Example: "1 2 N" => PositionX: 1, PositionY: 2, Direction: N</para>
        /// </summary>
        /// <param name="setupInstructions"></param>
        public Rover(string setupInstructions, Plateu plateu)
        {
            //Set rover position and direction
            Int32.TryParse(setupInstructions.Split(" ")[0], out _positionX);
            Int32.TryParse(setupInstructions.Split(" ")[1], out _positionY);
            _direction = setupInstructions.Split(" ")[2];

            //Set Plateu boundaries
            _plateu = plateu;
        }

        /// <summary>
        /// Turns rover's direction to left, depends on the current direction heading
        /// </summary>
        public void TurnLeft()
        {
            switch (_direction)
            {
                case "N":
                    _direction = "W";
                    break;
                case "W":
                    _direction = "S";
                    break;
                case "S":
                    _direction = "E";
                    break;
                default:
                    _direction = "N";
                    break;
            }
        }

        /// <summary>
        /// Turns rover's direction to right, depends on the current direction heading
        /// </summary>
        public void TurnRight()
        {
            switch (_direction)
            {
                case "N":
                    _direction = "E";
                    break;
                case "E":
                    _direction = "S";
                    break;
                case "S":
                    _direction = "W";
                    break;
                default:
                    _direction = "N";
                    break;
            }
        }

        /// <summary>
        /// Moves rover by one grid size while moving assuming (x, y) is (x, y+1)
        /// </summary>
        public void MoveForward()
        {
            //Rover can't move out of the plateu, also considering that
            //If Rover tried to move out of the plateu it's current postion won't change 
            switch (_direction)
            {
                case "N":
                    _positionY += (_plateu.MaxPositionY >= _positionY+1 ? 1 : 0);
                    break;
                case "E":
                    _positionX += (_plateu.MaxPositionX >= _positionX+1 ? 1 : 0);
                    break;
                case "S":
                    _positionY -= (_plateu.MinPositionY <= _positionY-1 ? 1 : 0);
                    break;
                default:
                    _positionX -= (_plateu.MinPositionX <= _positionY-1 ? 1: 0);
                    break;
            }
        }

        /// <summary>
        /// Executes series of commands provided by char list
        /// </summary>
        /// <param name="commands">Series of commands: L,R, M</param>
        public void ExecuteCommands(List<char> commands)
        {
            foreach (var command in commands)
            {
                //Execute command by command type
                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        MoveForward();
                        break;
                }
            }
        }

        /// <summary>
        /// Prints rover's current postions and direction in a format => "PositionX PositionY Direction". Exp: "1 2 N"
        /// </summary>
        public void PrintRoverCurrentState()
        {
            Console.WriteLine($"{_positionX} {_positionY} {_direction}");
        }

    }
}
