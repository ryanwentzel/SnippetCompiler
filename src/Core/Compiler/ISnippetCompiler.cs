using System.CodeDom.Compiler;

namespace Core.Compiler
{
    /// <summary>
    /// Represents a snippet compiler.
    /// </summary>
    public interface ISnippetCompiler
    {
        CompilerResults CompileExecutable(Snippet snippet);
    }
}
