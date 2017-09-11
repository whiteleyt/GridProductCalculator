using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridProduct;
using System.Diagnostics;

namespace GridProductTest
{
    [TestClass]
    public class GridProductCalculatorTest
    {
        GridProductCalculator gridProductCalculator = new GridProductCalculator();

        [TestMethod]
        public void Should_return_the_distinct_3_adjacent_numbers_When_i_pass_the_data_from_the_test()
        {
            var grid = new int[][]
            {
                new int[] { 8,  2,  22, 97, 38, 15, 0,  40, 0,  75 },
                new int[] { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87 },
                new int[] { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71 },
                new int[] { 52, 70, 95, 23, 4,  60, 11, 42, 69, 24 },
                new int[] { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92 },
                new int[] { 24, 47, 32, 60, 99, 3,  45, 2,  44, 75 },
                new int[] { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38 },
                new int[] { 67, 26, 20, 68, 2,  62, 12, 20, 95, 63 },
                new int[] { 24, 55, 58, 5,  66, 73, 99, 26, 97, 17 },
                new int[] { 21, 36, 23, 9,  75, 0,  76, 44, 20, 45 }
            };

            var expectedCount = 574;

            var actualCount = gridProductCalculator.DistinctThreeAdjacentNumbers(grid);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Should_return_the_largest_product_of_3_adjacent_integers_When_i_pass_the_data_from_the_test()
        {
            var grid = new int[][]
            {
                new int[] { 8,  2,  22, 97, 38, 15, 0,  40, 0,  75 },
                new int[] { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87 },
                new int[] { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71 },
                new int[] { 52, 70, 95, 23, 4,  60, 11, 42, 69, 24 },
                new int[] { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92 },
                new int[] { 24, 47, 32, 60, 99, 3,  45, 2,  44, 75 },
                new int[] { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38 },
                new int[] { 67, 26, 20, 68, 2,  62, 12, 20, 95, 63 },
                new int[] { 24, 55, 58, 5,  66, 73, 99, 26, 97, 17 },
                new int[] { 21, 36, 23, 9,  75, 0,  76, 44, 20, 45 }
            };

            var expectedCount = 667755;

            var actualCount = gridProductCalculator.LargestProductOfNAdjacentIntegers(grid, 3);

            Assert.AreEqual(expectedCount, actualCount);
        }

        

        [TestMethod]
        public void Should_return_count_of_28_for_adjacent_ints_When_all_values_are_distinct_in_4x3()
        {
            var grid = new int[][]
            {
                new int[] { 1, 2,  3,  4 },
                new int[] { 5, 6,  7,  8 },
                new int[] { 9, 10, 11, 12 },
            };

            var expectedCount = 28;

            var actualCount = gridProductCalculator.DistinctThreeAdjacentNumbers(grid);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Should_return_count_of_48_for_adjacent_ints_When_all_values_are_distinct_in_4x4()
        {
            var grid = new int[][]
            {
                new int[] { 1,  2,  3,  4 },
                new int[] { 5,  6,  7,  8 },
                new int[] { 9,  10, 11, 12 },
                new int[] { 13, 14, 15, 16 },
            };

            var expectedCount = 48;

            var actualCount = gridProductCalculator.DistinctThreeAdjacentNumbers(grid);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Should_return_max_product_When_4x4_grid_supplied()
        {
            var grid = new int[][]
            {
                new int[] { 1,  2,  3,  4 },
                new int[] { 5,  6,  7,  8 },
                new int[] { 9,  10, 11, 12 },
                new int[] { 13, 14, 15, 16 },
            };

            var expectedCount = 15 * 16;

            var actualCount = gridProductCalculator.LargestProductOfNAdjacentIntegers(grid, 2);

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
