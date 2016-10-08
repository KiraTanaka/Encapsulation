using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame15
{
    public class ImmutableGame : Game
    {
        public ImmutableGame(List<int> sequenceOfNumbers):base(sequenceOfNumbers)
        {}
        public override IGame Shift(int value)
        {
            if (value >= ValueInTiles.Length)
                throw new ArgumentException();
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
            return new ImmutableGame(newSequenceOfNumbers);
        }
    }
}
