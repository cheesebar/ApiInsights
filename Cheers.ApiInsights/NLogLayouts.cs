using Microsoft.AspNetCore.Http;
using NLog;
using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting.Server;
using System.Linq;
using Microsoft.AspNetCore.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Features;
namespace Cheers.ApiInsights
{
    [LayoutRenderer("apiinsight-start")]
    public class StartApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            var _apiInsightsKeys = httpContext.RequestServices.GetService<IApiInsightsKeys>();

            if (httpContext != null)
            {
                if (httpContext.Items.TryGetValue(_apiInsightsKeys.StartTimeName, out var start) == true)
                {
                    builder.Append(start.ToString());
                }
            }
        }
    }

    [LayoutRenderer("apiinsight-time")]
    public class TimeApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            var _apiInsightsKeys = httpContext.RequestServices.GetService<IApiInsightsKeys>();

            if (httpContext != null)
            {
                if (httpContext.Items.TryGetValue(_apiInsightsKeys.StopWatchName, out var stopWatch) == true)
                {
                    builder.Append((stopWatch as Stopwatch).ElapsedMilliseconds.ToString());
                }
            }
        }
    }

    [LayoutRenderer("apiinsight-protocol")]
    public class ProtocolApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            builder.Append(httpContext?.Request?.Protocol);
        }
    }


    [LayoutRenderer("apiinsight-host")]
    public class HostApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            builder.Append(httpContext?.Request?.Host.Host);
        }
    }
    [LayoutRenderer("apiinsight-port")]
    public class PortApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            builder.Append(httpContext?.Request?.Host.Port);
        }
    }
    [LayoutRenderer("apiinsight-path")]
    public class PathApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            builder.Append(httpContext?.Request?.Path);
        }
    }
    [LayoutRenderer("apiinsight-query")]
    public class QueryApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            builder.Append(httpContext?.Request?.QueryString);
        }
    }
    [LayoutRenderer("apiinsight-clientip")]
    public class ClientIPApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            var features = httpContext.Features;

            var clientIp = ReflectorHelper.GetProp<System.Net.IPAddress>(features, "RemoteIpAddress");

            builder.Append(clientIp.ToString());
        }
    }
    [LayoutRenderer("apiinsight-serverip")]
    public class ServerIPApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            var features = httpContext.Features;

            var serverIp = ReflectorHelper.GetProp<System.Net.IPAddress>(features, "LocalIpAddress");

            builder.Append(serverIp.ToString());
        }
    }
    [LayoutRenderer("apiinsight-authenticate")]
    public class QuthorizeApiInsightRenderer : LayoutRenderer
    {
        protected async override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;

            if(httpContext != null)
            {
                var authorize = httpContext.RequestServices.GetService<IRequestIsAuthenticate>();

                var authenticates = await authorize.IsAuthenticateAsync();

                builder.Append(authenticates);
            }
        }
    }
    [LayoutRenderer("apiinsight-httpstatus")]
    public class HttpStatusApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext == null)
            {
                return;
            }
            builder.Append(httpContext.Response.StatusCode);
        }
    }
    [LayoutRenderer("apiinsight-application")]
    public class ApplicationApiInsightRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var env = HttpContextProvider.Current?.RequestServices?.GetService<IHostingEnvironment>();
            builder.Append(env?.ApplicationName);
        }
    }
    [LayoutRenderer("apiinsight-request-user")]
    public class UserLayoutRenderer : LayoutRenderer
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        protected async override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextProvider.Current;
            if (httpContext != null)
            {
                if (httpContext != null)
                {
                    var authorize = httpContext.RequestServices.GetService<IRequestIsAuthenticate>();
                    var userName = await authorize.AuthenticatedUserName();
                    builder.Append(userName);
                }
            }
        }
    }
    [LayoutRenderer("apiinsight-request-url")]
    public class UrlLayoutRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var context = HttpContextProvider.Current;

            if(context == null)
            {
                return;
            }

            var url = context?.Request?.Host + context?.Request?.Path + context?.Request?.QueryString.ToString();
            builder.Append(url);
        }
    }
    [LayoutRenderer("apiinsight-request-servername")]
    public class ServerLayoutRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var context = HttpContextProvider.Current;
            if (context != null)
            {
                var server = context.RequestServices.GetService<IServer>();
            }
            builder.Append(context?.Request?.Host);
        }
    }
    [LayoutRenderer("apiinsight-request-exception")]
    public class ExceptionLayoutRenderer : LayoutRenderer
    {
        public string Exception { get; set; }
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            if(HttpContextProvider.Current == null)
            {
                return;
            }

            var exception = Exception ?? HttpContextProvider.Current?.Features?.Get<IExceptionHandlerFeature>()?.Error?.ToString();
            builder.Append(exception?.ToString());
        }
    }
}
