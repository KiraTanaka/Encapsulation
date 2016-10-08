using System;
using NUnit.Framework;
using ConsoleGame15;
using System.Collections.Generic;

namespace Game15Test
{
    [TestFixture]
    public class GameTests : GameTestsBase
    {
        public GameTests()
        {
            gameWithCorrectSequence = new Game(correctSequenceOfNumbers);
        }
       
    }
}
