using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.AdjacentIntegers
{
    /// <summary>
    /// collects adjacent grid integers in an upwards direction
    /// </summary>
    public class UpAdjacentGridIntegers : IAdjacentGridIntegers
    {
        public IEnumerable<int[]> GetAdjacentIntegers(GridAdjacentIntegerWindow gridWindow)
        {
            ArgumentCheck.IsNull(gridWindow, nameof(gridWindow));

            for (int x = gridWindow.MinX; x <= gridWindow.MaxX; x++)
            {
                int[] current = new int[gridWindow.WindowSize];
                for (int i = 0; i < gridWindow.WindowSize; i++)
                {
                    current[i] = gridWindow.GridData[gridWindow.MaxY - i][x];
                }

                yield return current;
            }
        }
    }
}
