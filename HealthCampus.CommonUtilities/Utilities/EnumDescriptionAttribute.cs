using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthCampus.CommonUtilities
{
    /// <summary>
    /// Атрибут, который используется для описания отдельного enum
    /// </summary>
    public class EnumDescriptionAttribute : Attribute
    {
        /// <summary>
        /// Описание объекта
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Создание нового атрибута
        /// </summary>
        /// <param name="text">Описание объекта</param>
        public EnumDescriptionAttribute(string text)
        {
            Text = text;
        }

        //public EnumDescriptionAttribute(Type resourceManagerProvider, string resourceKey)
        //{
        //    Text = Utils.LookupResource(resourceManagerProvider, resourceKey);
        //}

        //internal class Utils
        //{
        //    /// <summary>
        //    /// Получение значения из ресурса
        //    /// </summary>
        //    /// <param name="resourceManagerProvider"></param>
        //    /// <param name="resourceKey"></param>
        //    /// <returns></returns>
        //    internal static string LookupResource(Type resourceManagerProvider, string resourceKey)
        //    {
        //        foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties())
        //        {
        //            if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
        //            {
        //                var resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
        //                return resourceManager.GetString(resourceKey);
        //            }
        //        }

        //        return resourceKey; // Fallback with the key name
        //    }
        //}
    }


    public static class EnumDescriptionAttributeExtensions
    {
        public static string GetDisplayName<T>(this T source)
        {
            var type = source.GetType();
            var attribute = type.GetCustomAttribute<EnumDescriptionAttribute>(false);
            return attribute?.Text ?? source.ToString();
        }
    }
}
