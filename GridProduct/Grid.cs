using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using GridProduct.GridVisitor;

namespace GridProduct
{
    /// <summary>
    /// The grid validates the grid data and provides access to grid data
    /// </summary>
    public class Grid
    {
        private readonly int _adjacentIntegers;
        private readonly int[][] _gridData;
        public Grid(int[][] gridData, int adjacentIntegers)
        {
            ArgumentCheck.IsNull(gridData, nameof(gridData));
            ErrorIfAnyArrayNotPopulated(gridData);
            ErrorIfJaggedArray(gridData);
            _gridData = gridData;
            MaxX = gridData.Length > 0 ? gridData[0].Length : 0;
            MaxY = gridData.Length;
            _adjacentIntegers = adjacentIntegers;

            ErrorAdjacentIntegersExceedsMaxXOrMaX(MaxX, MaxY, _adjacentIntegers);
        }

        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public int[][] GridData
        {
            get { return _gridData; }
        }

        /// <summary>
        /// Applies the grid visitor to the grid by providing a grid window to process
        /// </summary>
        /// <param name="gridVisitor"></param>
        public void Apply(IGridVisitor gridVisitor)
        {
            ArgumentCheck.IsNull(gridVisitor, nameof(gridVisitor));

            for (int y = 0; y <= MaxY - _adjacentIntegers; y++)
            {
                for (int x = 0; x <= MaxX - _adjacentIntegers; x++)
                {
                    gridVisitor.VisitGridWindow(new GridAdjacentIntegerWindow(_gridData, x, y, _adjacentIntegers));
                }
            }
        }

        private static void ErrorIfAnyArrayNotPopulated(int [][] gridData)
        {
            if (gridData.Any(a => a == null))
            {
                throw new InvalidOperationException("the grid data is invalid. It contains null arrays");
            }
        }

        private static void ErrorIfJaggedArray(int[][] gridData)
        {
            var distinctArrayLengths = gridData
                .Select(a => a.Length)
                .Distinct()
                .Count();

            if (distinctArrayLengths > 1)
            {
                throw new InvalidOperationException("the grid does not support jagged arrays");
            }
        }

        private static void ErrorAdjacentIntegersExceedsMaxXOrMaX(int maxX, int maxY, int adjacentIntegers)
        {
            if (adjacentIntegers > maxX || adjacentIntegers > maxY)
            {
                throw new InvalidOperationException("adjacant integers cannot exeed grid size");
            }
        }
    }
}
