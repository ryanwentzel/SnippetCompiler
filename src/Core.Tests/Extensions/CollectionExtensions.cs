using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Core.Tests.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<string> AsEnumerable(this StringCollection collection)
        {
            return collection.Cast<string>();
        }

        public static string ToDelimitedString(this StringCollection collection, string delimiter)
        {
            return string.Join(delimiter, collection.AsEnumerable());
        }

        public static IEnumerable<CompilerError> AsEnumerable(this CompilerErrorCollection collection)
        {
            return collection.Cast<CompilerError>();
        }

        public static string GetDisplayString(this CompilerErrorCollection collection)
        {
            return string.Join(
                Environment.NewLine, collection.AsEnumerable().Select(error => error.ToString()));
        }
    }
}
