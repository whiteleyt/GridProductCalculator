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
        [TestMethod]
        public void Should_return_all_left_up_adjacent_integers_When_iterated()
        {
            var grid = new Grid(new int[][]
           {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
           });

            var expectedAdjacentValues = new int[][]
                {
                new int[] { 9, 5 },
                new int[] { 8, 4 },
                new int[] { 6, 2 },
                new int[] { 5, 1 },
            };

            var actualAdjacentValues = new LeftUpAdjacentGridIntegers(grid, 2).ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }

        [TestMethod]
        public void Should_return_all_left_up_adjacent_integers_When_iterated_with_max_width()
        {
            var grid = new Grid(new int[][]
           {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
           });

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 9, 5, 1 },
            };

            var actualAdjacentValues = new LeftUpAdjacentGridIntegers(grid, 3).ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }

        [TestMethod]
        public void Should_return_all_left_up_adjacent_integers_When_iterated_with_min_width()
        {
            var grid = new Grid(new int[][]
           {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
           });

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 4 },
                new int[] { 3 },
                new int[] { 2 },
                new int[] { 1 },
            };

            var actualAdjacentValues = new LeftUpAdjacentGridIntegers(grid, 1).ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }

        [TestMethod]
        public void Should_error_When_constructor_supplied_with_null()
        {
            AssertEx.AssertThrows<ArgumentNullException>(
             () => new LeftUpAdjacentGridIntegers(null, 2),
             "Value cannot be null.\r\nParameter name: grid");
        }

        [TestMethod]
        public void Should_error_When_adjacent_integers_is_less_than_one()
        {
            var grid = new Grid(new int[][]
            {
                new int[] { }
            });

            AssertEx.AssertThrows<ArgumentException>(
             () => new LeftUpAdjacentGridIntegers(grid, 0),
             "Value cannot be less than 1.\r\nParameter name: adjacentIntegers");
        }

        [TestMethod]
        public void Should_error_When_adjacent_integers_greater_than_maxX()
        {
            var grid = new Grid(new int[][]
            {
                new int[] { }
            });

            AssertEx.AssertThrows<ArgumentException>(
             () => new LeftUpAdjacentGridIntegers(grid, 1),
             "adjacent integer length 1 cannot be greater than Max X 0");
        }
    }
}