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
    public class RightDownAdjacentGridIntegers : AdjacentGridIntegers
    {
        public RightDownAdjacentGridIntegers(Grid grid, int adjacentIntegers) : base(grid, adjacentIntegers)
        {
            ErrorIfAdjacentIntegersGreaterThanMaxX(adjacentIntegers);
            ErrorIfAdjacentIntegersGreaterThanMaxY(adjacentIntegers);
        }

        public override IEnumerator<int[]> GetEnumerator()
        {
            for (int y = 0; y <= _grid.MaxY - _adjacentIntegers; y++)
            {
                for (int x = 0; x <= _grid.MaxX - _adjacentIntegers; x++)
                {
                    int[] current = new int[_adjacentIntegers];
                    for (int i = 0; i < _adjacentIntegers; i++)
                    {
                        current[i] = _grid.GridData[y + i][x + i];
                    }

                    yield return current;
                }
            }
        }
    }
}

