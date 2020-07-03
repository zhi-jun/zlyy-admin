using System;
using System.ComponentModel;

namespace ZLYY.Utils.Extensions
{
    /// <summary>
    /// Enum extension
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get description attribute value of the enum
        /// </summary>
        /// <param name="value">enum</param>
        /// <param name="nameInstead">if the the enum type has no DescriptionAttribute, return the name instead</param>
        /// <returns></returns>
        public static string ToDescription(this Enum value, bool nameInstead = true)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            var field = type.GetField(name);
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute == null && nameInstead)
            {
                return name;
            }
            return attribute?.Description;
        }
    }
}