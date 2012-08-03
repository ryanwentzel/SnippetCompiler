using System;
using System.IO;

using Core.Helpers;

namespace Core
{
    internal sealed class WorkingDirectory
    {
        /// <summary>
        /// Gets the full path to the directory.
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// Instantiates a new instance of the <see cref="WorkingDirectory"/> class using a default path.
        /// </summary>
        internal WorkingDirectory()
        {
            _path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp");
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="WorkingDirectory"/> class using the specified 
        /// path.
        /// </summary>
        /// <param name="path">The path to the working directory.</param>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="ArgumentException">path is empty or whitespace.</exception>
        internal WorkingDirectory(string path)
        {
            Throw.IfNullOrWhitespace(path);
            _path = path;
        }

        /// <summary>
        /// Creates the working directory is does not already exist.
        /// </summary>
        internal void EnsureDirectoryExists()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }

        /// <summary>
        /// Returns a random file name.
        /// </summary>
        /// <param name="extension">The file's extension.</param>
        /// <returns>A string representing the full path to a random file inside the working directory.</returns>
        internal string GetRandomFileName(string extension = "tmp")
        {
            Throw.IfNullOrWhitespace(extension);
            return Path.ChangeExtension(Path.Combine(_path, Path.GetRandomFileName()), extension);
        }

        /// <summary>
        /// Allows the <see cref="WorkingDirectory"/> to be used anywhere a string is required.
        /// </summary>
        /// <param name="directory">The working directory.</param>
        /// <returns>A string representing the full path to the working directory.</returns>
        public static implicit operator string(WorkingDirectory directory)
        {
            return directory._path;
        }

        public override string ToString()
        {
            return _path;
        }
    }
}
