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
    public class UpAdjacentGridIntegers : AdjacentGridIntegers
    {
        public UpAdjacentGridIntegers(Grid grid, int adjacentIntegers) : base(grid, adjacentIntegers)
        {
            ErrorIfAdjacentIntegersGreaterThanMaxY(adjacentIntegers);
        }

        public override IEnumerator<int[]> GetEnumerator()
        {
            for (int y = _grid.MaxY - 1; y >= _adjacentIntegers - 1; y--)
            {
                for (int x = _grid.MaxX - 1; x >= 0; x--)
                {
                    int[] current = new int[_adjacentIntegers];
                    for (int i = _adjacentIntegers - 1; i >= 0; i--)
                    {
                        current[i] = _grid.GridData[y - i][x];
                    }

                    yield return current;
                }
            }
        }
    }
}
