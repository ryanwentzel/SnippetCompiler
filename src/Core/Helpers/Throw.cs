using System;

namespace Core.Helpers
{
    internal static class Throw
    {
        internal static void IfNullOrWhitespace(string arg, string argumentName = "arg")
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            if (string.IsNullOrWhiteSpace(arg))
            {
                throw new ArgumentException("Argument cannot be empty or whitespace.", argumentName);
            }
        }

        internal static void IfNull(object arg, string argumentName = "arg")
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
