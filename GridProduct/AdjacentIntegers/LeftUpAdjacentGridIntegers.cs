using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.AdjacentIntegers
{
    /// <summary>
    /// collects adjacent grid integers in a diagonal left up direction
    /// </summary>
    public class LeftUpAdjacentGridIntegers : AdjacentGridIntegers
    {
        public LeftUpAdjacentGridIntegers(Grid grid, int adjacentIntegers) : base(grid, adjacentIntegers)
        {
            ErrorIfAdjacentIntegersGreaterThanMaxX(adjacentIntegers);
            ErrorIfAdjacentIntegersGreaterThanMaxY(adjacentIntegers);
        }

        public override IEnumerator<int[]> GetEnumerator()
        {
            for (int y = _grid.MaxY - 1; y >= _adjacentIntegers - 1; y--)
            {
                for (int x = _grid.MaxX - 1; x >= _adjacentIntegers - 1; x--)
                {
                    int[] current = new int[_adjacentIntegers];
                    for (int i = 0; i < _adjacentIntegers; i++)
                    {
                        current[i] = _grid.GridData[y - i][x - i];
                    }

                    yield return current;
                }
            }
        }
    }
}
