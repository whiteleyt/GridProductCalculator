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
    public class RightAdjacentGridIntegers : AdjacentGridIntegers
    {
        public RightAdjacentGridIntegers(Grid grid, int adjacentIntegers) : base(grid, adjacentIntegers)
        {
            ErrorIfAdjacentIntegersGreaterThanMaxX(adjacentIntegers);
        }

        public override IEnumerator<int[]> GetEnumerator()
        {
            for (int y = 0; y < _grid.MaxY; y++)
            {
                for (int x = 0; x <= _grid.MaxX - _adjacentIntegers; x++)
                {
                    int[] current = new int[_adjacentIntegers];
                    for (int i = 0; i < _adjacentIntegers; i++)
                    {
                        current[i] = _grid.GridData[y][x + i];
                    }

                    yield return current;
                }
            }
        }
    }
}
