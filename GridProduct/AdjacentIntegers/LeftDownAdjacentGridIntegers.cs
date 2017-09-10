using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.AdjacentIntegers
{
    /// <summary>
    /// collects adjacent grid integers in a diagonal left down direction
    /// </summary>
    public class LeftDownAdjacentGridIntegers : AdjacentGridIntegers
    {
        public LeftDownAdjacentGridIntegers(Grid grid, int adjacentIntegers) : base(grid, adjacentIntegers)
        {
            ErrorIfAdjacentIntegersGreaterThanMaxX(adjacentIntegers);
            ErrorIfAdjacentIntegersGreaterThanMaxY(adjacentIntegers);
        }

        public override IEnumerator<int[]> GetEnumerator()
        {
            for (int y = 0; y <= _grid.MaxY - _adjacentIntegers; y++)
            {
                for (int x = _grid.MaxX - 1; x >= _adjacentIntegers - 1; x--)
                {
                    int[] current = new int[_adjacentIntegers];
                    for (int i = _adjacentIntegers - 1; i >= 0; i--)
                    {
                        current[i] = _grid.GridData[y + i][x - i];
                    }

                    yield return current;
                }
            }
        }
    }
}
