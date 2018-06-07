using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-protocol")]
    public class ProtocolApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(ProtocolLayout);
    }
}
