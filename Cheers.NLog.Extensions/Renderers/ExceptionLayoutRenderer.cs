using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-request-exception")]
    public class ExceptionLayoutRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(ExceptionLayout);
    }
}
