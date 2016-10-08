using System;
using NUnit.Framework;
using ConsoleGame15;
using System.Collections.Generic;

namespace Game15Test
{
    [TestFixture]
    public class ImmutableGameTests : GameTests
    {
        public ImmutableGameTests()
        {
            gameWithCorrectSequence = new ImmutableGame(correctSequenceOfNumbers);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public override void Initialization_IncorrectFieldSize_ReturnException()
        {
            ImmutableGame game = new ImmutableGame(sequenceOfNumbersWithIncorrectSize);
        }
        [Test]
        public override void CheckingUniquenessOfNumbers_UniqueSequenceOfNumbers_ReturnTrue()
        {
            ImmutableGame game = new ImmutableGame(correctSequenceOfNumbers);
            Assert.True(game.CheckingUniquenessOfNumbers(correctSequenceOfNumbers));
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public override void CheckingUniquenessOfNumbers_NotUniqueSequenceOfNumbers_ReturnException()
        {
            ImmutableGame game = new ImmutableGame(notUniqueCorrectSequenceOfNumbers);
        }
        [Test]
        public override void Shift_ExistingValue_TilesMoved()
        {
            IGame game = gameWithCorrectSequence.Shift(7);
            List<int> newSequenceOfNumberse = new List<int>() { 1, 6, 3, 4, 5, 0, 8, 2, 7 };
            List<int> newSequenceOfNumbersInNewGame = new List<int>();
            List<int> newSequenceOfNumbersInOldGame = new List<int>();
            foreach (var valueTile in gameWithCorrectSequence.Tiles)
            {
                newSequenceOfNumbersInOldGame.Add(valueTile);
            }
            foreach (var valueTile in game.Tiles)
            {
                newSequenceOfNumbersInNewGame.Add(valueTile);
            }
            for (int i = 0; i < correctSequenceOfNumbers.Count; i++)
            {
                Assert.AreEqual(newSequenceOfNumberse[i], newSequenceOfNumbersInNewGame[i]);
            }

            for (int i = 0; i < correctSequenceOfNumbers.Count; i++)
            {
                if (i != 5 && i != 8)
                    Assert.AreEqual(newSequenceOfNumberse[i], newSequenceOfNumbersInOldGame[i]);
                else
                    Assert.AreNotEqual(newSequenceOfNumberse[i], newSequenceOfNumbersInOldGame[i]);
            } 
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public override void Shift_NonexistentValue_ReturnException()
        {
            gameWithCorrectSequence.Shift(15);
        }
        [Test]
        [ExpectedException(typeof(Exception))]
        public override void Shift_ExistingValueWithoutZeroNeighbor_ReturnException()
        {
            gameWithCorrectSequence.Shift(8);
        }
    }
}
