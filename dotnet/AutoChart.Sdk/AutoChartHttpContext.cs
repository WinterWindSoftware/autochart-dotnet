using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

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
            var current = new AutoChartHttpContext();
            current.LoadCookies();
            return current;
        }

        private void LoadCookies()
        {
            var ctx = HttpContext.Current;
            if(ctx != null)
            {
            //TODO: read from cookie rather than hardcoded values
                //ctx.Request.Cookies.
            }
            VisitorId = "53cf8ee65f9c61490c000001";
            SessionId = "53d0d26a5f9c614884000000";
        }
    }
}
