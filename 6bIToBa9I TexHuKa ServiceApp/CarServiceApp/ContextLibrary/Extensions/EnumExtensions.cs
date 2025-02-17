using System.ComponentModel;
using System.Reflection;

namespace ContextLibrary.Extensions
{
    public static class EnumExtensions
    {
        // Метод для получения описания элемента перечисления
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
