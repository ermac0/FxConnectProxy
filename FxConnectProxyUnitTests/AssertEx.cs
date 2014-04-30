using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    public static class AssertEx
    {
        public static void Throws(Action action)
        {
            if (action == null)
            {
                throw new AssertFailedException("Expected an action - null passed.");
            }

            var result = false;
            try
            {
                action();
            }
            catch
            {
                result = true;
            }

            if (!result)
            {
                throw new AssertFailedException("Exception not thrown. Expecting exception being thrown.");
            }
        }

        public static void Throws<TException>(Action action)
            where TException : Exception
        {
            if (action == null)
            {
                throw new AssertFailedException("Expected an action - null passed.");
            }

            var result = false;
            try
            {
                action();
            }
            catch (TException)
            {
                result = true;
            }
            catch (Exception ex)
            {
                throw new AssertFailedException(string.Format(@"Expected exception not thrown. Expecting: ""{0}"" got ""{1}"".", typeof(TException).FullName, ex.GetType().FullName));
            }

            if (!result)
            {
                throw new AssertFailedException("Exception not thrown. Expected exception being thrown.");
            }
        }
    }
}

