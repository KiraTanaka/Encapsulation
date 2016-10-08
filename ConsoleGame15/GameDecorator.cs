using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame15
{
    class GameDecorator: IGameDecorator
    {
        public int[,] Tiles { get; set; }
        public int[][,] ValueInTiles { get; set; }
        public int Size { get; set; }
        public List<int,int> History { get; set; }
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
            History new int[Size, Size];
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
            List<int> newSequenceOfNumbers = new List<int>();
            foreach (var valueTile in Tiles)
            {
                newSequenceOfNumbers.Add(valueTile);
            }
            newSequenceOfNumbers[location[0, 0] * Size + location[0, 1]] = valueNeighbor;
            newSequenceOfNumbers[zeroNeighbor[0, 0] * Size + zeroNeighbor[0, 1]] = value;
            return this;
        }
    }
}
