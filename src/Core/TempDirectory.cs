using System;
using System.IO;

using Core.Helpers;

namespace Core
{
    public sealed class TempDirectory
    {
        /// <summary>
        /// Gets the full path to the directory.
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// Instantiates a new instance of the <see cref="TempDirectory"/> class using a default path.
        /// </summary>
        internal TempDirectory()
        {
            _path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp");
            EnsureDirectoryExists();
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="TempDirectory"/> class using the specified 
        /// path.
        /// </summary>
        /// <param name="path">The path to the temp directory.</param>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="ArgumentException">path is empty or whitespace.</exception>
        internal TempDirectory(string path)
        {
            Throw.IfNullOrWhitespace(path);
            _path = path;
            EnsureDirectoryExists();
        }

        /// <summary>
        /// Creates the directory if it does not already exist.
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
        /// <returns>A string representing the full path to a random file inside the directory.</returns>
        internal string GetRandomFileName(string extension = "tmp")
        {
            Throw.IfNullOrWhitespace(extension);
            return Path.ChangeExtension(Path.Combine(_path, Path.GetRandomFileName()), extension);
        }

        /// <summary>
        /// Allows the <see cref="TempDirectory"/> to be used anywhere a string is required.
        /// </summary>
        /// <param name="directory">The temp directory.</param>
        /// <returns>A string representing the full path to the directory.</returns>
        public static implicit operator string(TempDirectory directory)
        {
            return directory._path;
        }

        public override string ToString()
        {
            return _path;
        }
    }
}
