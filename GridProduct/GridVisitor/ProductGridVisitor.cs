using GridProduct.AdjacentIntegers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.GridVisitor
{
    /// <summary>
    /// Calculates the largest product of n adjacent integers
    /// </summary>
    public class ProductGridVisitor : IGridVisitor
    {
        // We only need to use 4 enumerators because the product will be the same in both direction
        private readonly IAdjacentGridIntegers _upAdjacentGridIntegers = new UpAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _rightAdjacentGridIntegers = new RightAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _rightUpAdjacentGridIntegers = new RightUpAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _rightDownAdjacentGridIntegers = new RightDownAdjacentGridIntegers();
        
        public void VisitGridWindow(GridAdjacentIntegerWindow gridWindow)
        {
            ArgumentCheck.IsNull(gridWindow, nameof(gridWindow));

            var max = _upAdjacentGridIntegers.GetAdjacentIntegers(gridWindow)
                    .Concat(_rightAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                    .Concat(_rightUpAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                    .Concat(_rightDownAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                    .Select(Product)
                    .Max();

            if (max > LargestProduct)
            {
                LargestProduct = max;
            }
        }

        public long LargestProduct { get; private set; }

        private static long Product(int[] source)
        {
            long product = 1;
            foreach (var value in source)
            {
                product *= value;
            }

            return product;
        }
    }
}
