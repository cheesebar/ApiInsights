using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;
using Microsoft.AspNetCore.Http.Features;

namespace Cheers.ApiInsights
{
    /// <summary>
    ///     中间件，监控所有请求
    /// </summary>
    public class ApiInsightMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serverProvider;
        private readonly IApiInsightsKeys _apiInsightsKeys;
        private readonly ILogger<ApiInsightMiddleware> _logger;
        private HttpContext _httpContext;

        public ApiInsightMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILogger<ApiInsightMiddleware> logger)
        {
            _next = next;
            _serverProvider = serviceProvider;
            _apiInsightsKeys = _serverProvider.GetService<IApiInsightsKeys>();
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _httpContext = httpContext;

            var flag = SetValues();

            await _next(httpContext);

            if (flag == true)
            {
                ApiInsight();
            }
        } 


        /// <summary>
        ///     获取最终匹配的 方法
        /// </summary>
        /// <returns></returns>
        private ActionDescriptor GetSelectedActionDescriptor()
        {
            var route = _httpContext.Features.Get<IRoutingFeature>()?.RouteData;
            if (route == null)
            {
                return null;
            }
            else
            {
                var attrRoute = route.Routers.FirstOrDefault(t => t is MvcAttributeRouteHandler) as MvcAttributeRouteHandler;

                if (attrRoute?.Actions?.Length > 0)
                {
                    return attrRoute.Actions[0];
                }
            }
            return GetSelectedActionDescriptorCore(route);
        }

        private ActionDescriptor GetSelectedActionDescriptorCore(RouteData route)
        {
            var serviceProvider = HttpContextProvider.Current.RequestServices;
            var _actionSelector = serviceProvider.GetService<IActionSelector>();
            var routeContext = new RouteContext(_httpContext) { RouteData = route };
            var candidates = _actionSelector.SelectCandidates(routeContext);
            var actionDescriptor = _actionSelector.SelectBestCandidate(routeContext, candidates);
            return actionDescriptor;
        }

        private bool IsIgnore()
        {
            var actionDescriptor = GetSelectedActionDescriptor() as ControllerActionDescriptor;
            if (actionDescriptor == null)
            {
                return false;
            }
            else
            {
                var noInsight = actionDescriptor.MethodInfo.GetCustomAttribute<NoInsightAttribute>();
                return noInsight != null;
            }
        }

        private bool TryGetValues(out (Stopwatch StopWatch, DateTime CreateTime) values)
        {
            var flag1 = _httpContext.Items.TryGetValue(_apiInsightsKeys.StopWatchName, out var stopWatch);
            var flag2 = _httpContext.Items.TryGetValue(_apiInsightsKeys.StartTimeName, out var createTime);

            if (flag1 & flag2)
            {
                values = (stopWatch as Stopwatch, (DateTime)createTime);

                return true;
            }
            values = default;
            return false;
        }
        private bool SetValues()
        {
            if (!TryGetValues(out var values))
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                _httpContext.Items[_apiInsightsKeys.StopWatchName] = stopWatch;
                _httpContext.Items[_apiInsightsKeys.StartTimeName] = DateTime.Now;

                return true;
            }
            return false;
        }
        private void ApiInsight()
        {
            if (!IsIgnore())
            {
                _logger.LogInformation(string.Empty);
            }
        }
    }
}
