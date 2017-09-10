﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridProduct;
using GridProduct.AdjacentIntegers;

namespace GridProductTest
{
    [TestClass]
    public class RightUpAdjacentGridIntegersTest
    {
        [TestMethod]
        public void Should_return_all_right_up_adjacent_integers_When_iterated()
        {
            var grid = new Grid(new int[][]
           {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
           });

            var expectedAdjacentValues = new int[][]
                {
                new int[] { 7, 5 },
                new int[] { 8, 6 },
                new int[] { 4, 2 },
                new int[] { 5, 3 },
            };

            var actualAdjacentValues = new RightUpAdjacentGridIntegers(grid, 2).ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }

        [TestMethod]
        public void Should_return_all_right_up_adjacent_integers_When_iterated_with_max_width()
        {
            var grid = new Grid(new int[][]
           {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
           });

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 7, 5, 3 },
            };

            var actualAdjacentValues = new RightUpAdjacentGridIntegers(grid, 3).ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }

        [TestMethod]
        public void Should_return_all_right_up_adjacent_integers_When_iterated_with_min_width()
        {
            var grid = new Grid(new int[][]
           {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
           });

            var expectedAdjacentValues = new int[][]
             {
                new int[] { 3 },
                new int[] { 4 },
                new int[] { 1 },
                new int[] { 2 },
            };

            var actualAdjacentValues = new RightUpAdjacentGridIntegers(grid, 1).ToArray();

            AssertEx.AreEqual(expectedAdjacentValues, actualAdjacentValues);
        }

        [TestMethod]
        public void Should_error_When_constructor_supplied_with_null()
        {
            AssertEx.AssertThrows<ArgumentNullException>(
             () => new RightUpAdjacentGridIntegers(null, 2),
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
             () => new RightUpAdjacentGridIntegers(grid, 0),
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
             () => new RightUpAdjacentGridIntegers(grid, 1),
             "adjacent integer length 1 cannot be greater than Max X 0");
        }
    }
}
