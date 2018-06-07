using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-path")]
    public class PathApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(PathLayout);
    }
}
