using GridProduct.AdjacentIntegers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.GridVisitor
{
    /// <summary>
    /// Calculates collection of 3 distinct adjacent integers
    /// </summary>
    public class Distinct3AdjacentGridVisitor : IGridVisitor
    {
        private readonly IAdjacentGridIntegers _upAdjacentGridIntegers = new UpAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _downAdjacentGridIntegers = new DownAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _leftAdjacentGridIntegers = new LeftAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _rightAdjacentGridIntegers = new RightAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _leftUpAdjacentGridIntegers = new LeftUpAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _leftDownAdjacentGridIntegers = new LeftDownAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _rightUpAdjacentGridIntegers = new RightUpAdjacentGridIntegers();
        private readonly IAdjacentGridIntegers _rightDownAdjacentGridIntegers = new RightDownAdjacentGridIntegers();

        private List<Tuple<int, int, int>> _distinct3Adjacent = new List<Tuple<int, int, int>>();
        
        public void VisitGridWindow(GridAdjacentIntegerWindow gridWindow)
        {
            ArgumentCheck.IsNull(gridWindow, nameof(gridWindow));

            var distinct = _upAdjacentGridIntegers.GetAdjacentIntegers(gridWindow)
                .Concat(_downAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                .Concat(_leftAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                .Concat(_rightAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                .Concat(_leftUpAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                .Concat(_leftDownAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                .Concat(_rightUpAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                .Concat(_rightDownAdjacentGridIntegers.GetAdjacentIntegers(gridWindow))
                .Select(a => Tuple.Create(a[0], a[1], a[2]))
                .Distinct();

            _distinct3Adjacent.AddRange(distinct);
        }

        public int GetDistinctCount()
        {
            return _distinct3Adjacent.Distinct().Count();
        }
    }
}
