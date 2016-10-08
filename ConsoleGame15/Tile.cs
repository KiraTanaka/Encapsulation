using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleGame15
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
        public Tile() { }
        public Tile(int x = 0, int y = 0, int value = 0)
        {
            X = x;
            Y = y;
            Value = value;
        }
        public double IsNeighbor(Tile other)
        {
            var deltaX = X - other.X;
            var deltaY = Y - other.Y;
            var distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            return distance;
        }
    }
}
