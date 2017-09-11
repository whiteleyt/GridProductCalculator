using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct
{
    /// <summary>
    /// Provides a window of grid data to be processed 
    /// </summary>
    public class GridAdjacentIntegerWindow
    {
        public GridAdjacentIntegerWindow(int[][] gridData, int minX, int minY, int windowSize)
        {
            ArgumentCheck.IsNull(gridData, nameof(gridData));
            ArgumentCheck.IsLessThanZero(minX, nameof(minX));
            ArgumentCheck.IsLessThanZero(minY, nameof(minY));
            ArgumentCheck.IsLessThanZero(windowSize, nameof(windowSize));

            GridData = gridData;
            MinX = minX;
            MinY = minY;
            MaxX = minX + windowSize - 1;
            MaxY = minY + windowSize - 1;
            WindowSize = windowSize;
        }

        public int[][] GridData { get; private set; }
        public int MinX { get; private set; }
        public int MinY { get; private set; }
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public int WindowSize { get; private set; }
    }
}
