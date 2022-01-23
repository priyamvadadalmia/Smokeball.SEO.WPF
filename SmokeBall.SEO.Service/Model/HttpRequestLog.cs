using System.Net;

namespace SmokeBall.SEO.Service.Model
{
    internal class HttpRequestLog
    {
        public HttpWebRequest Request { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public object PostBody { get; set; }
        public string Response { get; set; }
    }
}