using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace AutoChart.Sdk
{
    /// <summary>
    /// Loads data related to a website visitor from AutoChart cookies available in current HTTP context
    /// </summary>
    public class AutoChartHttpContext
    {
        private AutoChartHttpContext() { }

        /// <summary>
        /// Unique ID generated for visitor. Fetched from long-term persistent cookie.
        /// </summary>
        public string VisitorId { get; private set; }

        /// <summary>
        /// Unique ID generated for the current visitor session. Fetched from session-only cookie.
        /// </summary>
        public string SessionId { get; private set; }

        /// <summary>
        /// Gets the current context from cookies available in the HTTP request.
        /// </summary>
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
                VisitorId = GetCookieIdValue("ac_visitor", ctx);
                SessionId = GetCookieIdValue("ac_session", ctx);
            }
        }

        private static string GetCookieIdValue(string name, HttpContext ctx)
        {
            var cookie = ctx.Request.Cookies.Get(name);
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                return JsonConvert.DeserializeObject<AutoChartCookieContents>(HttpUtility.UrlDecode(cookie.Value)).Id;
            }
            return null;
        }
    }

    public class AutoChartCookieContents
    {
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
    }
}
