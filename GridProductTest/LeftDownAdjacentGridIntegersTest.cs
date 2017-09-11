using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridProduct;
using GridProduct.AdjacentIntegers;

namespace GridProductTest
{
    [TestClass]
    public class LeftDownAdjacentGridIntegersTest
    {
        private readonly LeftDownAdjacentGridIntegers leftDownAdjacentGridIntegers = new LeftDownAdjacentGridIntegers();

        [TestMethod]
        public void Should_return_all_left_down_adjacent_integers_When_iterated()
        {
            var gridwindow = new GridAdjacentIntegerWindow(new int[][]
          {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
          }, 0, 0, 3);

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 3, 5, 7 },
            };

            var actualAdjacentValues = leftDownAdjacentGridIntegers
                 .GetAdjacentIntegers(gridwindow)
                 .ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }
    }
}