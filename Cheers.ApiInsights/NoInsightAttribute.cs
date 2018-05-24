using System;

namespace Cheers.ApiInsights
{
    /// <summary>
    ///     不对该方法做监控
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NoInsightAttribute : Attribute
    {
    }
}
