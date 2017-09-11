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
    public class DownAdjacentGridIntegersTest
    {
        private readonly DownAdjacentGridIntegers downAdjacentGridIntegers = new DownAdjacentGridIntegers();

        [TestMethod]
        public void Should_return_all_down_adjacent_integers_When_iterated()
        {
            var gridwindow = new GridAdjacentIntegerWindow(new int[][]
           {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
           },0,0, 3);

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 3, 6, 9 },
            };

            var actualAdjacentValues = downAdjacentGridIntegers
                 .GetAdjacentIntegers(gridwindow)
                 .ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }
    }
}
