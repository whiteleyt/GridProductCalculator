using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GridProduct
{
    /// <summary>
    /// The grid validates the grid data and provides access to grid data
    /// </summary>
    public class Grid
    {
        private readonly int _maxX, _maxY;
        private readonly int[][] _gridData;
        public Grid(int[][] gridData)
        {
            ArgumentCheck.IsNull(gridData, nameof(gridData));
            ErrorIfAnyArrayNotPopulated(gridData);
            ErrorIfJaggedArray(gridData);
            _gridData = gridData;
            _maxX = gridData.Length > 0 ? gridData[0].Length : 0;
            _maxY = gridData.Length;
        }

        public int MaxX
        {
            get { return _maxX; }
        }

        public int MaxY
        {
            get { return _maxY; }
        }

        public int[][] GridData
        {
            get { return _gridData; }
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
    }
}
