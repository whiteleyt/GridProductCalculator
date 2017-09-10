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
        public static void IsNull(object arg, string parameterName)
        {
            if(arg == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
