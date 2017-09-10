using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridProduct;

namespace GridProductTest
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void Should_error_When_constructor_supplied_with_null()
        {
            AssertEx.AssertThrows<ArgumentNullException>(
             () => new Grid(null),
             "Value cannot be null.\r\nParameter name: gridData");
        }

        [TestMethod]
        public void Should_error_When_constructor_supplied_with_jagged_array()
        {
            var jaggedArray = new int[][] 
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6, 7 }
            };

            AssertEx.AssertThrows<InvalidOperationException>(
              () => new Grid(jaggedArray),
              "the grid does not support jagged arrays");
        }

        [TestMethod]
        public void Should_error_When_array_contains_null_entry()
        {
            AssertEx.AssertThrows<InvalidOperationException>(
              () => new Grid(new int[1][]),
              "the grid data is invalid. It contains null arrays");
        }
    }
}
