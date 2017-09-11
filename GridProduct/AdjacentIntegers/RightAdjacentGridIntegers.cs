using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.AdjacentIntegers
{
    /// <summary>
    /// collects adjacent grid integers in a right direction
    /// </summary>
    public class RightAdjacentGridIntegers : IAdjacentGridIntegers
    {
        public IEnumerable<int[]> GetAdjacentIntegers(GridAdjacentIntegerWindow gridWindow)
        {
            ArgumentCheck.IsNull(gridWindow, nameof(gridWindow));

            for (int y = gridWindow.MinY; y <= gridWindow.MaxY; y++)
            {
                int[] current = new int[gridWindow.WindowSize];
                for (int i = 0; i < gridWindow.WindowSize; i++)
                {
                    current[i] = gridWindow.GridData[y][gridWindow.MinX + i];
                }

                yield return current;
            }
        }
    }
}
