using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ConsoleGame15
{
   
    public class Game : IGame
    {
        public int[,] Tiles { get; set; }
        public int[][,] ValueInTiles { get; set; }
        public int Size { get; set; }
        public Game(List<int> sequenceOfNumbers)
        {
            int indexRow = 0;
            int indexColumn = 0;
            FieldSizeCalculation(sequenceOfNumbers);
            CheckingUniquenessOfNumbers(sequenceOfNumbers);
            Tiles = new int[Size, Size];
            ValueInTiles = new int[sequenceOfNumbers.Count][,];
            foreach (var number in sequenceOfNumbers)
            {
                Tiles[indexRow, indexColumn] = number;
                ValueInTiles[number] = new int[,] { { indexRow, indexColumn } };
                indexColumn = (indexColumn == Size-1) ? 0 : indexColumn + 1;
                indexRow = (indexColumn == 0) ? indexRow + 1 : indexRow;
            }
        }
        public bool FieldSizeCalculation(List<int> sequenceOfNumbers)
        {
            Size = (int)Math.Sqrt(sequenceOfNumbers.Count());
            if (Math.Pow(Size, 2) != sequenceOfNumbers.Count())
                throw new ArgumentException();
            return true;
        }
        public bool CheckingUniquenessOfNumbers(List<int> sequenceOfNumbers)
        {
            foreach (var number in sequenceOfNumbers)
            {
                if(sequenceOfNumbers.Where(el => el == number).Count()>1)
                    throw new ArgumentException();
            }
            return true;
        }
        public int this[int x, int y]
        {
            get
            {
                if (x < Size && y < Size)
                    return Tiles[x, y];
                else
                    throw new ArgumentException();
            }
        }
        public int[,] GetLocation(int value)
        {
            if (value <= ValueInTiles.Length)
                return ValueInTiles[value];
            else
                throw new ArgumentException();
        }
        public virtual IGame Shift(int value)
        {
            if (value>=ValueInTiles.Length)
                throw new ArgumentException();
            int valueNeighbor = 0;
            int[,] location = ValueInTiles[value];

            int[,] zeroNeighbor = null;
            if (IsNeighbor(location, ValueInTiles[valueNeighbor]) <= 1)
                zeroNeighbor = ValueInTiles[valueNeighbor];
            else
                throw new Exception();
            Tiles[location[0,0], location[0,1]] = valueNeighbor;
            Tiles[zeroNeighbor[0, 0], zeroNeighbor[0, 1]] = value;
            ValueInTiles[valueNeighbor] = location;
            ValueInTiles[value] = zeroNeighbor;
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
