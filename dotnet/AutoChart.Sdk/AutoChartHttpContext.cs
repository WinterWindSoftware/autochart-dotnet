using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoChart.Sdk
{
    /// <summary>
    /// Loads data related to a website visitor from AutoChart cookies available in current HTTP context
    /// </summary>
    public class AutoChartHttpContext
    {
        private AutoChartHttpContext() { }

        public string VisitorId { get; private set; }
        public string SessionId { get; private set; }

        public static AutoChartHttpContext Current()
        {
            //TODO: read from cookie rather than hardcoded values
            return new AutoChartHttpContext() {
                VisitorId = "53cf8ee65f9c61490c000001",
                SessionId = "53d0d26a5f9c614884000000"
            };
        }
    }
}
