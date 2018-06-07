using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-authenticate")]
    public class AuthorizeApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(AuthLayout);
    }
}
