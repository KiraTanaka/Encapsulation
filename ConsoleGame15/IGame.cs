using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame15
{
    public interface IGame
    {
        int[,] Tiles { get; set; }
        int[][,] ValueInTiles { get; set; }
        int this[int x, int y] { get; }
        int Size { get; set; }
        int[,] GetLocation(int value);
        IGame Shift(int value);
    }
}
