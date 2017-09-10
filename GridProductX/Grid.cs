using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GridProduct
{
    public class Grid
    {
        public Grid(int[][] gridData)
        {
            ErrorIfJaggedArray(gridData);
        }

        private static void ErrorIfJaggedArray(int[][] gridData)
        {
            var distinctArrayLengths = gridData
                .Select(a => a.Length)
                .Distinct()
                .Count();

            if (distinctArrayLengths > 1)
            {
                throw new InvalidOperationException("the grid does not support jagged arrays");
            }
        }
    }
}
