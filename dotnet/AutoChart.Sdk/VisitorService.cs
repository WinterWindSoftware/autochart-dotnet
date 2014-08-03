using System;
using System.Linq;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using Newtonsoft.Json;

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

        private WebClient _webClient;

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
            this.Authenticate();
        }

        public void Authenticate()
        {
            var url = string.Format("{0}/authenticate", _apiRootUrl);
            var postVars = new NameValueCollection();
            postVars.Add("apikey", _apiReadKey);
            using (var client = GetWebClient())
            {
                client.UploadValues(url, "POST", postVars);
                //If no error thrown, we're 200 OK, and a cookie will have been sent in response
            }
        }

        public VisitorSummary GetVisitorSummary(string visitorId)
        {
            if(string.IsNullOrEmpty(visitorId))
            {
                throw new ArgumentException("visitorId must be specified");
            }
            var url = string.Format("{0}/visitors/{1}/summary", _apiRootUrl, visitorId);
            VisitorSummary visitor;
            using (var client = GetWebClient())
            {
                var data = client.OpenRead(url);
                var reader = new StreamReader(data);
                var json = reader.ReadToEnd();
                visitor = JsonConvert.DeserializeObject<ApiResultWrapper<VisitorSummary>>(json).result;
            }
            return visitor;
        }

        public VisitorSummary GetVisitorSummaryByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("email must be specified");
            }
            //TODO: implement
            return new VisitorSummary();
        }


        private WebClient GetWebClient()
        {
            if(_webClient == null)
            {
                _webClient = new CookieAwareWebClient();
            }
            _webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            return _webClient;
        }
    }

    internal class ApiResultWrapper<T>
    {
        public T result { get; set; }
    }

    internal class CookieAwareWebClient : WebClient
    {
        private CookieContainer cc = new CookieContainer();
        private string lastPage;

        protected override WebRequest GetWebRequest(System.Uri address)
        {
            WebRequest R = base.GetWebRequest(address);
            if (R is HttpWebRequest)
            {
                HttpWebRequest WR = (HttpWebRequest)R;
                WR.CookieContainer = cc;
                if (lastPage != null)
                {
                    WR.Referer = lastPage;
                }
            }
            lastPage = address.ToString();
            return R;
        }
    }
}
