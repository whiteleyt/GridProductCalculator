using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridProduct;
using GridProduct.AdjacentIntegers;

namespace GridProductTest
{
    [TestClass]
    public class LeftAdjacentGridIntegersTest
    {
        private readonly LeftAdjacentGridIntegers leftAdjacentGridIntegers = new LeftAdjacentGridIntegers();

        [TestMethod]
        public void Should_return_all_left_adjacent_integers_When_iterated()
        {
            var gridwindow = new GridAdjacentIntegerWindow(new int[][]
           {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
           }, 0, 0, 3);

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 3, 2, 1 },
                new int[] { 6, 5, 4 },
                new int[] { 9, 8, 7 },
            };

            var actualAdjacentValues = leftAdjacentGridIntegers
                .GetAdjacentIntegers(gridwindow)
                .ToArray();
            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }
    }
}
