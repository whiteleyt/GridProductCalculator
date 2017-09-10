using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.AdjacentIntegers
{
    public abstract class AdjacentGridIntegers : IEnumerable<int[]>
    {
        internal readonly Grid _grid;
        internal readonly int _adjacentIntegers;

        public AdjacentGridIntegers(Grid grid, int adjacentIntegers)
        {
            ArgumentCheck.IsNull(grid, nameof(grid));
            ArgumentCheck.IsLessThan(adjacentIntegers, 1, nameof(adjacentIntegers));

            _grid = grid;
            _adjacentIntegers = adjacentIntegers;
        }

        public abstract IEnumerator<int[]> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal void ErrorIfAdjacentIntegersGreaterThanMaxY(int adjacentIntegers)
        {
            if (adjacentIntegers > _grid.MaxY)
            {
                throw new ArgumentException($"adjacent integer length { adjacentIntegers } cannot be greater than Max Y { _grid.MaxY}");
            }
        }

        internal void ErrorIfAdjacentIntegersGreaterThanMaxX(int adjacentIntegers)
        {
            if (adjacentIntegers > _grid.MaxX)
            {
                throw new ArgumentException($"adjacent integer length { adjacentIntegers } cannot be greater than Max X { _grid.MaxX}");
            }
        }
    }
}
