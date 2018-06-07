using Cheers.ApiInsights.NLog.Layouts;
using Cheers.NLog.Extensions;
using NLog.LayoutRenderers;
using System;

namespace Cheers.ApiInsights.NLog.Renderers
{
    [LayoutRenderer("apiinsight-start")]
    public class StartApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(StartLayout);
    }
}
