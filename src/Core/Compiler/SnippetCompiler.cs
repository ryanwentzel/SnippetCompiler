using System.CodeDom.Compiler;
using System.Linq;
using System.Text;

using Core.Extensions;
using Core.Helpers;

namespace Core.Compiler
{
    /// <summary>
    /// The base class for implementations of <see cref="ISnippetCompiler"/>.
    /// </summary>
    public abstract class SnippetCompiler : ISnippetCompiler
    {
        protected TempDirectory TempDir { get; private set; }

        /// <summary>
        /// Instantiates a new instance of the <see cref="SnippetCompiler"/> class.
        /// </summary>
        protected SnippetCompiler()
        {
            TempDir = new TempDirectory();
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="SnippetCompiler"/> class.
        /// </summary>
        /// <param name="tempDirPath">The path to the temp directory.</param>
        protected SnippetCompiler(string tempDirPath)
        {
            TempDir = new TempDirectory(tempDirPath);
        }

        /// <summary>
        /// Compiles a <see cref="Snippet"/> as an executable.
        /// </summary>
        /// <param name="snippet">The snippet to compile.</param>
        /// <returns>An instance of <see cref="CompilerResults"/> representing the compilation result.</returns>
        public CompilerResults CompileExecutable(Snippet snippet)
        {
            Throw.IfNull(snippet);

            return CompileSnippet(snippet, true);
        }

        /// <summary>
        /// Compiles a <see cref="Snippet"/>.
        /// </summary>
        /// <param name="snippet">The snippet to compile.</param>
        /// <param name="generateExecutable">Flag that specifies whether to generate an executable.</param>
        /// <returns>An instance of <see cref="CompilerResults"/> representing the compilation result.</returns>
        protected CompilerResults CompileSnippet(Snippet snippet, bool generateExecutable = false)
        {
            string extension = generateExecutable ? "exe" : "dll";
            var parameters = new CompilerParameters(snippet.References.ToArray())
            {
                GenerateExecutable = generateExecutable,
                OutputAssembly = TempDir.GetRandomFileName(extension),

            };

            using (var provider = CodeDomProvider.CreateProvider(snippet.Language.GetDisplayName()))
            {
                return provider.CompileAssemblyFromSource(parameters, GenerateSource(snippet));
            }
        }

        protected abstract string GenerateHeader(Snippet snippet);

        protected abstract string GenerateFooter(Snippet snippet);

        protected string GenerateSource(Snippet snippet)
        {
            var builder = new StringBuilder(GenerateHeader(snippet));
            builder.AppendLine("            " + snippet.Code);
            builder.Append(GenerateFooter(snippet));

            return builder.ToString();
        }
    }
}
