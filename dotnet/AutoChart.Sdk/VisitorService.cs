using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AutoChart.Sdk
{
    /// <summary>
    /// Provides methods for fetching visitor related data
    /// from the AutoChart visitors REST API.
    /// </summary>
    public class VisitorService
    {
        const string DEFAULT_API_ROOT_URL = "https://portal.autochart.io/api";

        private readonly string _apiRootUrl;
        private readonly string _apiReadKey;

        public VisitorService(string apiReadKey) : this(apiReadKey, DEFAULT_API_ROOT_URL)
        {
        }

        public VisitorService(string apiReadKey, string apiRootUrl)
        {
            if(string.IsNullOrEmpty(apiReadKey))
            {
                throw new ArgumentException("apiReadKey must be specified");
            }
            _apiRootUrl = apiRootUrl;
            _apiReadKey = apiReadKey;
        }

        public VisitorSummary GetVisitorSummary(string visitorId)
        {
            if(string.IsNullOrEmpty(visitorId))
            {
                throw new ArgumentException("visitorId must be specified");
            }
            var url = string.Format("{0}/visitors/{1}/summary", _apiRootUrl, visitorId);
            using (var client = new WebClient())
            {                
                client.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                var data = client.OpenRead(url);
                var reader = new StreamReader(data);
                var json = reader.ReadToEnd();
                //TODO: complete implementation of this by mapping JSON into VisitorSummary object.
            }
            return null;
        }

        public VisitorSummary GetVisitorSummaryByEmail(string email)
        {
            //TODO: implement
            throw new NotImplementedException();
        }
    }
}
