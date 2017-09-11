using GridProduct;
using GridProduct.AdjacentIntegers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProductTest
{
    [TestClass]
    public class RightDownAdjacentGridIntegersTest
    {
        private readonly RightDownAdjacentGridIntegers rightDownAdjacentGridIntegers = new RightDownAdjacentGridIntegers();

        [TestMethod]
        public void Should_return_all_right_down_adjacent_integers_When_iterated_with_max_width()
        {
            var gridwindow = new GridAdjacentIntegerWindow(new int[][]
           {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
           }, 0, 0, 3);

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 1, 5, 9 },
            };

            var actualAdjacentValues = rightDownAdjacentGridIntegers
                 .GetAdjacentIntegers(gridwindow)
                 .ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }
    }
}
