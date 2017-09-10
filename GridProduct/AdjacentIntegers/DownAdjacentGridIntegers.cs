﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.AdjacentIntegers
{
    /// <summary>
    /// collects adjacent grid integers in a downwards direction
    /// </summary>
    public class DownAdjacentGridIntegers : AdjacentGridIntegers
    {
        public DownAdjacentGridIntegers(Grid grid, int adjacentIntegers) : base(grid, adjacentIntegers)
        {
            ErrorIfAdjacentIntegersGreaterThanMaxY(adjacentIntegers);
        }

        public override IEnumerator<int[]> GetEnumerator()
        {
            for (int y = 0; y <= _grid.MaxY - _adjacentIntegers; y++)
            {
                for (int x = 0; x < _grid.MaxX; x++)
                {
                    int[] current = new int[_adjacentIntegers];
                    for (int i = 0; i < _adjacentIntegers; i++)
                    {
                        current[i] = _grid.GridData[y+i][x];
                    }

                    yield return current;
                }
            }
        }
    }
}