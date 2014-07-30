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

        public static AutoChartHttpContext Load()
        {
            //TODO: read from cookie
            return new AutoChartHttpContext();
        }
    }
}
