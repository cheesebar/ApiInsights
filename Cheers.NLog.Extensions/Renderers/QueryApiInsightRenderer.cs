using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-query")]
    public class QueryApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(QueryLayout);
    }
}
