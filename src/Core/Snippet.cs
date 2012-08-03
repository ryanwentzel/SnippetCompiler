using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// Represents a code snippet.
    /// </summary>
    public class Snippet
    {
        /// <summary>
        /// Gets the collection of assembly references.
        /// </summary>
        public IList<string> References { get; private set; }

        /// <summary>
        /// Gets the collection of namespace imports.
        /// </summary>
        public IList<string> Imports { get; private set; }

        /// <summary>
        /// Gets or sets the code for this snippet.
        /// </summary>
        public string Code { get; set; }

        public Snippet()
        {
            References = new List<string>();
            Imports = new List<string>();
        }
    }
}
