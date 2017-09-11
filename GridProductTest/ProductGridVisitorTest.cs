using GridProduct;
using GridProduct.GridVisitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProductTest
{
    [TestClass]
    public class ProductGridVisitorTest
    {
        private ProductGridVisitor productGridVisitor = new ProductGridVisitor();

        [TestMethod]
        public void Should_return_max_product_of_3_ints_When_the_max_product_is_right()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            }, 0,0,3);

            var expectedCount = 504;

            productGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, productGridVisitor.LargestProduct);
        }

        [TestMethod]
        public void Should_return_max_product_of_3_ints_When_the_max_product_is_left()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 9, 8, 7 },
            }, 0, 0, 3);

            var expectedCount = 504;

            productGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, productGridVisitor.LargestProduct);
        }

        [TestMethod]
        public void Should_return_max_product_of_3_ints_When_the_max_product_is_down()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
            {
                new int[] { 1, 2, 7 },
                new int[] { 4, 5, 8 },
                new int[] { 3, 6, 9 },
            }, 0, 0, 3);

            var expectedCount = 504;

            productGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, productGridVisitor.LargestProduct);
        }

        [TestMethod]
        public void Should_return_max_product_of_3_ints_When_the_max_product_is_up()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
            {
                new int[] { 1, 2, 9 },
                new int[] { 4, 5, 8 },
                new int[] { 3, 6, 7 },
            }, 0, 0, 3);

            var expectedCount = 504;

            productGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, productGridVisitor.LargestProduct);
        }

        [TestMethod]
        public void Should_return_max_product_of_3_ints_When_the_max_product_is_right_down()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
            {
                new int[] { 7, 2, 3 },
                new int[] { 4, 8, 6 },
                new int[] { 1, 5, 9 },
            }, 0, 0, 3);

            var expectedCount = 504;

            productGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, productGridVisitor.LargestProduct);
        }

        [TestMethod]
        public void Should_return_max_product_of_3_ints_When_the_max_product_is_left_up()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
            {
                new int[] { 9, 2, 3 },
                new int[] { 4, 8, 6 },
                new int[] { 1, 5, 7 },
            }, 0, 0, 3);

            var expectedCount = 504;

            productGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, productGridVisitor.LargestProduct);
        }

        [TestMethod]
        public void Should_return_max_product_of_3_ints_When_the_max_product_is_right_up()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
            {
                new int[] { 1, 2, 9 },
                new int[] { 4, 8, 6 },
                new int[] { 7, 5, 3 },
            }, 0, 0, 3);

            var expectedCount = 504;

            productGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, productGridVisitor.LargestProduct);
        }

        [TestMethod]
        public void Should_return_max_product_of_3_ints_When_the_max_product_is_left_down()
        {
            var gridWindow = new GridAdjacentIntegerWindow(new int[][]
            {
                new int[] { 1, 2, 7 },
                new int[] { 4, 8, 6 },
                new int[] { 9, 5, 3 },
            }, 0, 0, 3);

            var expectedCount = 504;

            productGridVisitor.VisitGridWindow(gridWindow);

            Assert.AreEqual(expectedCount, productGridVisitor.LargestProduct);
        }

        [TestMethod]
        public void Should_error_When_gridWindow_is_null()
        {
            AssertEx.AssertThrows<ArgumentNullException>(
             () => productGridVisitor.VisitGridWindow(null),
             "Value cannot be null.\r\nParameter name: gridWindow");
        }
    }
}
