using System;
using NUnit.Framework;
using ConsoleGame15;
using System.Collections.Generic;

namespace Game15Test
{
    [TestFixture]
    public class GameDecoratorTests
    {   
        [Test]
        public  void Shift_ExistingValue_TilesMoved()
        {
            List<int> sequenceOfNumbers = new List<int>() { 1, 6, 3, 4, 5, 7, 8, 2, 0 };
            ImmutableGame game = new ImmutableGame(sequenceOfNumbers);
            IGame decorator = new GameDecorator(game);
            decorator.Shift(2);
            List<int> newSequenceOfNumbers = new List<int>() { 1, 6, 3, 4, 5, 7, 8, 0, 2};
            List<int> newSequenceOfNumbersInDecorator = new List<int>();
            List<int> newSequenceOfNumbersInOldGame = new List<int>();
            foreach (var valueTile in game.Tiles)
            {
                newSequenceOfNumbersInOldGame.Add(valueTile);
            }
            foreach (var valueTile in decorator.Tiles)
            {
                newSequenceOfNumbersInDecorator.Add(valueTile);
            }
            for (int i = 0; i < sequenceOfNumbers.Count; i++)
            {
                Assert.AreEqual(newSequenceOfNumbers[i], newSequenceOfNumbersInDecorator[i]);
            }

            for (int i = 0; i < sequenceOfNumbers.Count; i++)
            {
                if (i != 7 && i != 8)
                    Assert.AreEqual(newSequenceOfNumbers[i], newSequenceOfNumbersInOldGame[i]);
                else
                    Assert.AreNotEqual(newSequenceOfNumbers[i], newSequenceOfNumbersInOldGame[i]);
            }
        }
    }
}
