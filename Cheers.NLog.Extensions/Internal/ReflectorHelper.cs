using System;
using System.Text;

namespace Cheers.NLog.Extensions.Internal
{
    public class ReflectorHelper
    {
        public static T GetProp<T>(object instance, string propName)
        {
            var prop = instance.GetType().GetProperty(propName);
            var value = (T)prop.GetValue(instance);
            return value;
        }
        public static T GetField<T>(object instance, string fieldName)
        {
            var prop = instance.GetType().GetField(fieldName);
            var value = (T)prop.GetValue(instance);
            return value;
        }
    }
}
