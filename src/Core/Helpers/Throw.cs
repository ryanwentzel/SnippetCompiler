using System;

namespace Core.Helpers
{
    internal static class Throw
    {
        internal static void IfNullOrWhitespace(string value, string argumentName = "arg")
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Argument cannot be empty or whitespace.", argumentName);
            }
        }
    }
}
