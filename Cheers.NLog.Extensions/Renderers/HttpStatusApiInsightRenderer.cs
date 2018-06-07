using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-httpstatus")]
    public class HttpStatusApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(HttpStatusLayout);
    }
}
