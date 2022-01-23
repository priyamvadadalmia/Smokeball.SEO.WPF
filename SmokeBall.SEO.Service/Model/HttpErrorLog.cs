using System.Net;

namespace SmokeBall.SEO.Service.Model
{
    internal class HttpErrorLog
    {
        public HttpWebRequest Request { get; set; }
        public string Url { get; set; }
        public string ExceptionMessage { get; set; }
        public object PostBody { get; set; }
    }
}