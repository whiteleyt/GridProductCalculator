using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridProduct.GridVisitor;
using GridProduct;

namespace GridProductTest
{
    [TestClass]
    public class Distinct3AdjacentGridVisitorTest
    {
        private Distinct3AdjacentGridVisitor distinctAdjacentGridVisitor = new Distinct3AdjacentGridVisitor();

        [TestMethod]
        public void Should_return_count_of_one_for_adjacent_ints_When_all_values_are_same()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
             {
                new int[] { 1, 1, 1 },
                new int[] { 1, 1, 1 },
                new int[] { 1, 1, 1 },
            }, 0, 0, 3);

            var expectedCount = 1;

            distinctAdjacentGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, distinctAdjacentGridVisitor.GetDistinctCount());
        }

        [TestMethod]
        public void Should_return_count_of_16_for_adjacent_ints_When_all_values_are_distinct_in_3x3()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            }, 0, 0, 3);

            var expectedCount = 16;

            distinctAdjacentGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, distinctAdjacentGridVisitor.GetDistinctCount());
        }

        [TestMethod]
        public void Should_error_When_gridWindow_is_null()
        {
            AssertEx.AssertThrows<ArgumentNullException>(
             () => distinctAdjacentGridVisitor.VisitGridWindow(null),
             "Value cannot be null.\r\nParameter name: gridWindow");
        }
    }
}
