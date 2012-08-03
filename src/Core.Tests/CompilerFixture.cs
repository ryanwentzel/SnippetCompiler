using System;

using Core.Compiler;
using Core.Tests.Extensions;

using NUnit.Framework;

namespace Core.Tests
{
    /// <summary>
    /// Represents a test fixture for the <see cref="Compiler"/> class.
    /// </summary>
    [TestFixture]
    public class CompilerFixture
    {
        [Test]
        public void CompileExecutable_NullSnippet_Throws()
        {
            var compiler = new CSharpSnippetCompiler();
            Assert.Throws<ArgumentNullException>(() => compiler.CompileExecutable(null));
        }

        [Test]
        public void CompileExecutable_ValidSyntax_CompilesExecutable()
        {
            var snippet = new Snippet
            {
                Code = "Console.WriteLine(\"Hello World\");"
            };
            snippet.References.Add("System.dll");
            snippet.Imports.Add("System");

            var compiler = new CSharpSnippetCompiler("output");
            var results = compiler.CompileExecutable(snippet);

            Assert.That(results.Errors.Count == 0, results.Errors.GetDisplayString());
        }
    }
}
