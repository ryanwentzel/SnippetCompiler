using System;
using System.CodeDom.Compiler;
using System.Linq;

using Core.Extensions;

namespace Core
{
    public class Compiler
    {
        private readonly WorkingDirectory _workingDir;

        public Compiler()
        {
            _workingDir = new WorkingDirectory();
        }

        public CompilerResults CompileExe(Snippet snippet)
        {
            if (snippet == null)
            {
                throw new ArgumentException("snippet");
            }

            return CompileSnippet(snippet, true);
        }

        private CompilerResults CompileSnippet(Snippet snippet, bool generateExecutable = false)
        {
            string extension = generateExecutable ? "exe" : snippet.Language.GetFileExtension();
            var parameters = new CompilerParameters(snippet.References.ToArray())
            {
                GenerateExecutable = generateExecutable,
                OutputAssembly = _workingDir.GetRandomFileName(extension),
                
            };

            using (var provider = CodeDomProvider.CreateProvider(snippet.Language.GetDisplayName()))
            {
                return provider.CompileAssemblyFromSource(parameters, snippet.Code);
            }
        }
    }
}
