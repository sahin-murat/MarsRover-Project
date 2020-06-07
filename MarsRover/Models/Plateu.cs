using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models
{
    public class Plateu
    {
        public Plateu(string plateBoundaries)
        {
            Int32.TryParse(plateBoundaries.Split(" ")[0], out MaxPositionX);
            Int32.TryParse(plateBoundaries.Split(" ")[1], out MaxPositionY);
        }

        public int MaxPositionX = 0;
        public int MaxPositionY = 0;
        public int MinPositionX = 0;
        public int MinPositionY = 0;
    }
}
