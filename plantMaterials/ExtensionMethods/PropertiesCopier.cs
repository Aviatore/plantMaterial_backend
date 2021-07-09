using System;
using System.Collections;
using Microsoft.VisualBasic;

namespace plantMaterials.ExtensionMethods
{
    public static class PropertiesCopier
    {
        public static void CopyPropertiesFrom(this object to, object from)
        {
            var fromProperties = from.GetType().GetProperties();
            var toProperties = to.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                foreach (var toProperty in toProperties)
                {
                    var p = fromProperty.PropertyType.MakeGenericType();
                    
                    if (fromProperty.Name == toProperty.Name &&
                        fromProperty.PropertyType == toProperty.PropertyType)
                    {
                        Console.Out.WriteLine($"prop name: {fromProperty.Name}, prop type: {fromProperty.PropertyType}");
                        toProperty.SetValue(to, fromProperty.GetValue(from));
                        
                        break;
                    }
                }
            }
        }
    }
}