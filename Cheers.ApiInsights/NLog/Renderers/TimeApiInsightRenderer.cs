using Cheers.ApiInsights.NLog.Layouts;
using Cheers.NLog.Extensions;
using NLog.LayoutRenderers;
using System;

namespace Cheers.ApiInsights.NLog.Renderers
{
    [LayoutRenderer("apiinsight-time")]
    public class TimeApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(TimeLayout);
    }
}
