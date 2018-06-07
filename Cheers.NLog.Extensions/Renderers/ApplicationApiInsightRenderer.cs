using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-application")]
    public class ApplicationApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(AppLayout);
    }
}
