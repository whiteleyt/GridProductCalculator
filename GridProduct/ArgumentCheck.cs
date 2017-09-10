using System;
using System.Collections.Generic;
using System.Text;

namespace GridProduct
{
    /// <summary>
    /// Check arguments and throw an exception if invalid
    /// </summary>
    public static class ArgumentCheck
    {
        /// <summary>
        /// Throws ArgumentNullException if argument is null
        /// </summary>
        /// <param name="arg">argument</param>
        /// <param name="argumentName">argument name</param>
        public static void IsNull(object arg, string argumentName)
        {
            if(arg == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Throws an ArgumentException if the argument is less than zero
        /// </summary>
        /// <param name="arg">argument</param>
        /// <param name="argumentName">argument name</param>
        public static void IsLessThanZero(int arg, string argumentName)
        {
            IsLessThan(arg, 0, argumentName);
        }

        /// <summary>
        /// Throws an ArgumentException if the argument is less than the min value supplied
        /// </summary>
        /// <param name="arg">argument</param>
        /// <param name="minValue">minimum value</param>
        /// <param name="argumentName">argument name</param>
        public static void IsLessThan(int arg, int minValue, string argumentName)
        {
            if (arg < minValue)
            {
                throw new ArgumentException($"Value cannot be less than { minValue }.\r\nParameter name: { argumentName }");
            }
        }
    }
}
