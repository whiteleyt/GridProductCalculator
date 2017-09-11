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
             () => new Grid(null, 1),
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
              () => new Grid(jaggedArray, 1),
              "the grid does not support jagged arrays");
        }

        [TestMethod]
        public void Should_error_When_array_contains_null_entry()
        {
            AssertEx.AssertThrows<InvalidOperationException>(
              () => new Grid(new int[1][], 1),
              "the grid data is invalid. It contains null arrays");
        }

        [TestMethod]
        public void Should_error_When_adjacentIntegers_exceeds_maxX()
        {
            var grid = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 }
            };

            AssertEx.AssertThrows<InvalidOperationException>(
              () => new Grid(grid, 4),
              "adjacant integers cannot exeed grid size");
        }

        [TestMethod]
        public void Should_error_When_adjacentIntegers_exceeds_maxY()
        {
            var grid = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 4, 5 },
                new int[] { 7, 8 }
            };

            AssertEx.AssertThrows<InvalidOperationException>(
              () => new Grid(grid, 4),
              "adjacant integers cannot exeed grid size");
        }

        [TestMethod]
        public void Should_visit_all_windows_When_applying_visitor()
        {
            //TODO this will quire a mock visitor to test correctly
        }

        [TestMethod]
        public void Should_error_When_null_visitor_supplied()
        {
            var grid = new Grid(new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 4 }
            }, 2);

            AssertEx.AssertThrows<ArgumentNullException>(
             () => grid.Apply(null),
             "Value cannot be null.\r\nParameter name: gridVisitor");
        }
    }
}
