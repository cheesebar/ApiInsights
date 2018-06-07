using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-request-user")]
    public class UserLayoutRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(UserLayout);
    }
}
