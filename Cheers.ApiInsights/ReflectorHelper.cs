using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace Cheers.ApiInsights
{
    class ReflectorHelper
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
