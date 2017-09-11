using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.AdjacentIntegers
{
    public interface IAdjacentGridIntegers
    {
        IEnumerable<int[]> GetAdjacentIntegers(GridAdjacentIntegerWindow gridWindow);
    }
}
