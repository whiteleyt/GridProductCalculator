using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProduct.GridVisitor
{
    public interface IGridVisitor
    {
        void VisitGridWindow(GridAdjacentIntegerWindow gridWindow);
    }
}
