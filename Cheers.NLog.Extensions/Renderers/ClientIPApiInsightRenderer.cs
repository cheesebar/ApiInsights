using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-clientip")]
    public class ClientIPApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(ClientIPLayout);
    }
}
