using GridProduct.AdjacentIntegers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct
{
    /// <summary>
    /// Uses the grid enumerators to be able to query grid
    /// </summary>
    public class GridProductCalculator : IGridProductCalculator
    {
        /// <summary>
        /// Calculates the largest product of adjacent integers
        /// </summary>
        /// <param name="searchGrid">search grid</param>
        /// <param name="adjacentIntegers">adjacent integers</param>
        /// <returns>largest product</returns>
        public long LargestProductOfNAdjacentIntegers(int[][] searchGrid, int adjacentIntegers)
        {
            ArgumentCheck.IsNull(searchGrid, nameof(searchGrid));
            ArgumentCheck.IsLessThan(adjacentIntegers, 1, nameof(adjacentIntegers));

            var grid = new Grid(searchGrid);
            // We only need to use 4 enumerators because the product will be the same in both direction
            var adjacentValues = GetAdjacentValues(grid, adjacentIntegers,
                GetUpAdjacentGridIntegers,
                GetRightAdjacentGridIntegers,
                GetRightUpAdjacentGridIntegers,
                GetRightDownAdjacentGridIntegers);

            var largestProduct = adjacentValues
                                .AsParallel()
                                .Select(Product)
                                .Max();

            return largestProduct;
        }

        /// <summary>
        /// Calculates the number of distinct three adjacent numbers
        /// </summary>
        /// <param name="searchGrid">search grid data</param>
        /// <returns>distinct number of three adjacent numbers</returns>
        public int DistinctThreeAdjacentNumbers(int[][] searchGrid)
        {
            ArgumentCheck.IsNull(searchGrid, nameof(searchGrid));

            var grid = new Grid(searchGrid);
            var adjacentValues = GetAdjacentValues(grid, 3,
                GetUpAdjacentGridIntegers,
                GetDownAdjacentGridIntegers,
                GetLeftAdjacentGridIntegers,
                GetRightAdjacentGridIntegers,
                GetLeftUpAdjacentGridIntegers,
                GetLeftDownAdjacentGridIntegers,
                GetRightUpAdjacentGridIntegers,
                GetRightDownAdjacentGridIntegers);

            var distinctCount = adjacentValues
                                .AsParallel()
                                .Select(a => new { Value1 = a[0], Value2 = a[1], Value3 = a[2] })
                                .Distinct()
                                .Count();

            return distinctCount;
        }

        private static IEnumerable<int[]> GetAdjacentValues(Grid grid, int adjacentNumbers,params  Func<Grid, int, IEnumerable<int[]>>[] adjecentNumberFuncs)
        {
            var aggregatedAdjacentValues = adjecentNumberFuncs
                                    .AsParallel() // allow enumerators to run in parallel 
                                    .Select(a => a(grid, adjacentNumbers).ToArray()) // lambda to get results of each enumerator
                                    .ToArray() // begin parallel execution
                                    .SelectMany(a => a) // return result of all enumerators in a single collection
                                    .ToArray(); // call to array to make sure select many is ran before returning enumerable

            return aggregatedAdjacentValues;
        }

        private static long Product(int[] source)
        {
            long product = 1;
            foreach (var value in source)
            {
                product *= value;
            }

            return product;
        }

        private Func<Grid, int, IEnumerable<int[]>> GetUpAdjacentGridIntegers =>
           (grid, adjacentIntegers) => new UpAdjacentGridIntegers(grid, adjacentIntegers);
        private Func<Grid, int, IEnumerable<int[]>> GetDownAdjacentGridIntegers =>
            (grid, adjacentIntegers) => new DownAdjacentGridIntegers(grid, adjacentIntegers);
        private Func<Grid, int, IEnumerable<int[]>> GetLeftAdjacentGridIntegers =>
            (grid, adjacentIntegers) => new LeftAdjacentGridIntegers(grid, adjacentIntegers);
        private Func<Grid, int, IEnumerable<int[]>> GetRightAdjacentGridIntegers =>
            (grid, adjacentIntegers) => new RightAdjacentGridIntegers(grid, adjacentIntegers);
        private Func<Grid, int, IEnumerable<int[]>> GetRightUpAdjacentGridIntegers =>
            (grid, adjacentIntegers) => new RightUpAdjacentGridIntegers(grid, adjacentIntegers);
        private Func<Grid, int, IEnumerable<int[]>> GetRightDownAdjacentGridIntegers =>
            (grid, adjacentIntegers) => new RightDownAdjacentGridIntegers(grid, adjacentIntegers);
        private Func<Grid, int, IEnumerable<int[]>> GetLeftUpAdjacentGridIntegers =>
            (grid, adjacentIntegers) => new LeftUpAdjacentGridIntegers(grid, adjacentIntegers);
        private Func<Grid, int, IEnumerable<int[]>> GetLeftDownAdjacentGridIntegers =>
            (grid, adjacentIntegers) => new LeftDownAdjacentGridIntegers(grid, adjacentIntegers);
    }
}
