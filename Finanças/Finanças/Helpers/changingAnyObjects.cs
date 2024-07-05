using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;


namespace Finanças.Helpers
{
    public class changingAnyObjects
    {
        public static void UpdatePropertyValues(object source, object target)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source or/and Target");
            }

            Type typeSource = source.GetType();
            Type typeTarget = target.GetType();

            PropertyInfo[] propertyInfos = typeSource.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                PropertyInfo targetProperty = typeTarget.GetProperty(propertyInfo.Name);
                if (targetProperty != null && targetProperty.CanWrite)
                {
                    var value = propertyInfo.GetValue(source, null);
                    targetProperty.SetValue(target, value, null);
                }
            }
        }
    }
}