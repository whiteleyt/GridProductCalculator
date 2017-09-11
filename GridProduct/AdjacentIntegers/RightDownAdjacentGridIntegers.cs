using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.AdjacentIntegers
{
    /// <summary>
    /// collects adjacent grid integers in a diagonal right down direction
    /// </summary>
    public class RightDownAdjacentGridIntegers : IAdjacentGridIntegers
    {
        public IEnumerable<int[]> GetAdjacentIntegers(GridAdjacentIntegerWindow gridWindow)
        {
            ArgumentCheck.IsNull(gridWindow, nameof(gridWindow));

            int[] current = new int[gridWindow.WindowSize];
            for (int i = 0; i < gridWindow.WindowSize; i++)
            {
                current[i] = gridWindow.GridData[gridWindow.MinY + i][gridWindow.MinX + i];
            }

            yield return current;
        }
    }
}

