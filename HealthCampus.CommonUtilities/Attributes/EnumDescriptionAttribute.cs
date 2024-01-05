using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthCampus.CommonUtilities.Attributes
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

    }
}
