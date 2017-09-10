using System;
using System.Collections.Generic;
using System.Text;

namespace GridProduct
{
    public interface IGridProductCalculator
    {
        long LargestProductOfNAdjacentIntegers(int[][] searchGrid, int adjacentIntegers);
    }
}
