using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame15
{
    public class GameDecorator: IGame
    {
        public int[,] Tiles { get; set; }
        public int[][,] ValueInTiles { get; set; }
        public int Size { get; set; }
        public List<int> History { get; set; } = new List<int>();
        public IGame _component { get; }
        public int this[int x, int y]
        {
            get
            {
                return _component[x, y];
            }
        }
        public GameDecorator(IGame component)
        {
            this._component = component;
            int indexRow = 0;
            int indexColumn = 0;
            Size = component.Size;
            Tiles = new int[Size, Size];
            ValueInTiles = new int[component.ValueInTiles.Length][,];
            foreach (var item in component.Tiles)
            {
                Tiles[indexRow, indexColumn] = item;
                ValueInTiles[item] = new int[,] { { indexRow, indexColumn } };
                indexColumn = (indexColumn == Size - 1) ? 0 : indexColumn + 1;
                indexRow = (indexColumn == 0) ? indexRow + 1 : indexRow;
            }
        }

        public int[,] GetLocation(int value)
        {
            return _component.GetLocation(value);
        }

        public IGame Shift(int value)
        {
            if (value >= ValueInTiles.Length)
                throw new ArgumentNullException();
            int valueNeighbor = 0;
            int[,] location = ValueInTiles[value];

            int[,] zeroNeighbor = null;
            if (IsNeighbor(location, ValueInTiles[valueNeighbor]) <= 1)
                zeroNeighbor = ValueInTiles[valueNeighbor];
            else
                throw new Exception();
            Tiles[location[0, 0], location[0, 1]] = valueNeighbor;
            Tiles[zeroNeighbor[0, 0], zeroNeighbor[0, 1]] = value;
            ValueInTiles[valueNeighbor] = location;
            ValueInTiles[value] = zeroNeighbor;
            History.Add(value);
            return this;
        }
        public double IsNeighbor(int[,] location1, int[,] location2)
        {
            var deltaX = location1[0, 0] - location2[0, 0];
            var deltaY = location1[0, 1] - location2[0, 1];
            var distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            return distance;
        }
    }
}
