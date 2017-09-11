using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridProduct;
using GridProduct.AdjacentIntegers;

namespace GridProductTest
{
    [TestClass]
    public class LeftUpAdjacentGridIntegersTest
    {
        private readonly LeftUpAdjacentGridIntegers leftUpAdjacentGridIntegers = new LeftUpAdjacentGridIntegers();

        [TestMethod]
        public void Should_return_all_left_up_adjacent_integers_When_iterated()
        {
            var gridwindow = new GridAdjacentIntegerWindow(new int[][]
           {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
           }, 0, 0, 3);

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 9, 5, 1 },
            };

            var actualAdjacentValues = leftUpAdjacentGridIntegers
                 .GetAdjacentIntegers(gridwindow)
                 .ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }
    }
}