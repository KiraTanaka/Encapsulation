using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame15
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfNumbers = new List<int>() { 1,6,3,4,5,7,8,2,0};
            IGame game = new ImmutableGame(sequenceOfNumbers);
            IGame decorator = new GameDecorator(game);
            decorator.Shift(2);
            foreach (var item in decorator.Tiles)
            {
                
                Console.WriteLine(item);
            }
            Console.WriteLine("game");/*
            IGame newGame = game.Shift(2);
            foreach (var item in game.Tiles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("newGame");
            foreach (var item in newGame.Tiles)
            {
                Console.WriteLine(item);
            }*/
            Console.ReadLine();
        }
    }
}
