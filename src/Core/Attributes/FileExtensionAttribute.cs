using System;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FileExtensionAttribute : Attribute
    {
        public string Extension { get; set; }

        public FileExtensionAttribute(string extension)
        {
            Extension = extension;
        }
    }
}
