using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7_1
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class CustomNameAttribute : Attribute
    {
        public string CustomFieldName { get; }

        public CustomNameAttribute(string customFieldName)
        {
            CustomFieldName = customFieldName;
        }
    }
}
