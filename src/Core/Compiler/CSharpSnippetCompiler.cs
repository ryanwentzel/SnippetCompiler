using System.Text;

namespace Core.Compiler
{
    /// <summary>
    /// Represents a snippet compiler.
    /// </summary>
    public class CSharpSnippetCompiler : SnippetCompiler
    {
        public CSharpSnippetCompiler()
        {  
        }

        public CSharpSnippetCompiler(string tempDirPath)
            : base(tempDirPath)
        {   
        }

        protected override string GenerateHeader(Snippet snippet)
        {
            var builder = new StringBuilder();
            foreach (var @namespace in snippet.Imports)
            {
                builder.AppendFormat("using {0};", @namespace);
                builder.AppendLine();
            }
            builder.AppendLine("namespace SnippetCompiler");
            builder.AppendLine("{");
            builder.AppendLine("    public partial class UserSnippet");
            builder.AppendLine("    {");
            builder.AppendLine("        public static void Main(string[] args)");
            builder.AppendLine("        {");

            return builder.ToString();
        }

        protected override string GenerateFooter(Snippet snippet)
        {
            var builder = new StringBuilder();
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }
    }
}
