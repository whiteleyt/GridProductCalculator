using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridProduct;
using GridProduct.AdjacentIntegers;

namespace GridProductTest
{
    [TestClass]
    public class RightUpAdjacentGridIntegersTest
    {
        private readonly RightUpAdjacentGridIntegers rightUpAdjacentGridIntegers = new RightUpAdjacentGridIntegers();

        [TestMethod]
        public void Should_return_all_right_up_adjacent_integers_When_iterated_with_max_width()
        {
            var gridwindow = new GridAdjacentIntegerWindow(new int[][]
          {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
          }, 0, 0, 3);

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 7, 5, 3 },
            };

            var actualAdjacentValues = rightUpAdjacentGridIntegers
                 .GetAdjacentIntegers(gridwindow)
                 .ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }
    }
}
