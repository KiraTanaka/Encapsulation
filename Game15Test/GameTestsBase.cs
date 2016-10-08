using System;
using NUnit.Framework;
using ConsoleGame15;
using System.Collections.Generic;

namespace Game15Test
{
    public abstract class GameTestsBase
    {
        protected List<int> correctSequenceOfNumbers = new List<int>() { 1, 6, 3, 4, 5, 7, 8, 2, 0 };
        protected List<int> sequenceOfNumbersWithIncorrectSize = new List<int>() { 1, 6, 3, 4, 5, 2, 0 };
        protected List<int> notUniqueCorrectSequenceOfNumbers = new List<int>() { 1, 6, 1, 4, 8, 7, 8, 2, 0 };
        protected IGame gameWithCorrectSequence;

        [Test]
        public virtual void Initialization_FieldSize_ReturnCorrectSize()
        {
            Assert.AreEqual(gameWithCorrectSequence.Size, 3);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Initialization_IncorrectFieldSize_ReturnException()
        {
            List<int> sequenceOfNumbers = new List<int>() { 1, 6, 3, 4, 5, 2, 0 };
            Game game = new Game(sequenceOfNumbers);
        }
        [Test]
        public virtual void CheckingUniquenessOfNumbers_UniqueSequenceOfNumbers_ReturnTrue()
        {
            Game game = new Game(correctSequenceOfNumbers);
            Assert.True(game.CheckingUniquenessOfNumbers(correctSequenceOfNumbers));
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void CheckingUniquenessOfNumbers_NotUniqueSequenceOfNumbers_ReturnException()
        {
            Game game = new Game(notUniqueCorrectSequenceOfNumbers);
        }
        [Test]
        public virtual void Indexer_ExistingCoordinates_ReturnCorrectValue()
        {
            Assert.AreEqual(gameWithCorrectSequence[1, 2], 7);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Indexer_NonexistentCoordinates_ReturnException()
        {
            int value = gameWithCorrectSequence[3, 3];
        }
        [Test]
        public virtual void GetLocation_ExistingValue_ReturnCorrectCoordinates()
        {
            Assert.AreEqual(gameWithCorrectSequence.GetLocation(6), new int[,] { { 0, 1 } });
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void GetLocation_NonexistentValue_ReturnException()
        {
            int[,] coordinates = gameWithCorrectSequence.GetLocation(15);
        }
        [Test]
        public virtual void Shift_ExistingValue_TilesMoved()
        {
            gameWithCorrectSequence.Shift(7);
            List<int> newSequenceOfNumberse = new List<int>() { 1, 6, 3, 4, 5, 0, 8, 2, 7 };
            List<int> newSequenceOfNumbersInGame = new List<int>();
            foreach (var valueTile in gameWithCorrectSequence.Tiles)
            {
                newSequenceOfNumbersInGame.Add(valueTile);
            }
            for (int i = 0; i < correctSequenceOfNumbers.Count; i++)
            {
                Assert.AreEqual(newSequenceOfNumberse[i], newSequenceOfNumbersInGame[i]);
            }
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Shift_NonexistentValue_ReturnException()
        {
            gameWithCorrectSequence.Shift(15);
        }
        [Test]
        [ExpectedException(typeof(Exception))]
        public virtual void Shift_ExistingValueWithoutZeroNeighbor_ReturnException()
        {
            gameWithCorrectSequence.Shift(8);
        }
    }
}
