using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace Utilities
{
    public static class EnumExtentions
    {
        public static string StringValueOf(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString())!;
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static object EnumValueOf(Type enumType, string value)
        {
            string[] names = Enum.GetNames(enumType);
            foreach (string name in names)
            {
                if (((Enum)Enum.Parse(enumType, name)).StringValueOf().Equals(value))
                {
                    return Enum.Parse(enumType, name);
                }
            }

            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }
    }
}
