using System;
using System.Linq;

using Core.Attributes;

namespace Core.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the enum's display name.
        /// </summary>
        /// <param name="enumType">The <see cref="Enum"/>.</param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumType)
        {
            var attribute = enumType.GetCustomAttribute<EnumDisplayNameAttribute>();

            return attribute != null ? attribute.DisplayName : Enum.GetName(enumType.GetType(), enumType);
        }

        private static T GetCustomAttribute<T>(this Enum enumType) where T : Attribute
        {
            return enumType.GetType()
                           .GetField(enumType.ToString())
                           .GetCustomAttributes(typeof(T), false)
                           .FirstOrDefault() as T;
        }
    }
}
