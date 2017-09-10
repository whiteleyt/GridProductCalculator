using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.AdjacentIntegers
{
    /// <summary>
    /// collects adjacent grid integers in a diagonal right up direction
    /// </summary>
    public class RightUpAdjacentGridIntegers : AdjacentGridIntegers
    {
        public RightUpAdjacentGridIntegers(Grid grid, int adjacentIntegers) : base(grid, adjacentIntegers)
        {
            ErrorIfAdjacentIntegersGreaterThanMaxX(adjacentIntegers);
            ErrorIfAdjacentIntegersGreaterThanMaxY(adjacentIntegers);
        }

        public override IEnumerator<int[]> GetEnumerator()
        {
            for (int y = _grid.MaxY - 1; y >= _adjacentIntegers - 1; y--)
            {
                for (int x = 0; x <= _grid.MaxX - _adjacentIntegers; x++)
                {
                    int[] current = new int[_adjacentIntegers];
                    for (int i = 0; i < _adjacentIntegers; i++)
                    {
                        current[i] = _grid.GridData[y - i][x + i];
                    }

                    yield return current;
                }
            }
        }
    }
}
