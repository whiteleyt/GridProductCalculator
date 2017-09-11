using GridProduct.AdjacentIntegers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GridProduct.GridVisitor;

namespace GridProduct
{
    /// <summary>
    /// combines the grid and visitors to answer test questions
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
            // adjacent integers should be less than window
            ArgumentCheck.IsNull(searchGrid, nameof(searchGrid));
            ArgumentCheck.IsLessThan(adjacentIntegers, 1, nameof(adjacentIntegers));

            var productGridVisitor = new ProductGridVisitor();
            var grid = new Grid(searchGrid, adjacentIntegers);
            grid.Apply(productGridVisitor);

            return productGridVisitor.LargestProduct;
        }

        /// <summary>
        /// Calculates the number of distinct three adjacent numbers
        /// </summary>
        /// <param name="searchGrid">search grid data</param>
        /// <returns>distinct number of three adjacent numbers</returns>
        public int DistinctThreeAdjacentNumbers(int[][] searchGrid)
        {
            ArgumentCheck.IsNull(searchGrid, nameof(searchGrid));

            var distinct3AdjacentGridVisitor = new Distinct3AdjacentGridVisitor();
            var grid = new Grid(searchGrid, 3);
            grid.Apply(distinct3AdjacentGridVisitor);

            return distinct3AdjacentGridVisitor.GetDistinctCount();
        }
    }
}
