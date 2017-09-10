using GridProduct;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridProductTest
{
    static class AssertEx
    {
        /// <summary>
        /// A very basic method to assert an exception was thrown. 
        /// This is prefereable to ExpectedExceptionAttribue because I can check the exeption message 
        /// and it follows the Assert. pattern 
        /// </summary>
        /// <typeparam name="TExpectedException">The Type of exception that should be thrown</typeparam>
        /// <param name="methodUnderTest">method under test</param>
        /// <param name="message">the expected message. Ignored if null or empty</param>
        public static void AssertThrows<TExpectedException>(Action methodUnderTest, string message) where TExpectedException : Exception
        {
            ArgumentCheck.IsNull(methodUnderTest, nameof(methodUnderTest));
            var expectedExceptionType = typeof(TExpectedException);

            try
            {
                methodUnderTest();
                Assert.Fail($"Expected exception { expectedExceptionType.Name } { message }");
            }
            catch(Exception e)
            {
                Assert.AreEqual(expectedExceptionType, e.GetType());
                if(!string.IsNullOrEmpty(message))
                {
                    Assert.AreEqual(message, e.Message);
                }
            }
        }

        /// <summary>
        /// MSTest doesn't support comparing jagged arrays
        /// </summary>
        /// <param name="expected">expected value</param>
        /// <param name="actual">actuall value</param>
        public static void AreEqual(int[][] expected, int [][] actual)
        {
            ArgumentCheck.IsNull(expected, nameof(expected));
            ArgumentCheck.IsNull(actual, nameof(actual));

            Assert.AreEqual(expected.Length, actual.Length, "arrays not the same length");
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
