using Microsoft.Extensions.Logging;
using SmokeBall.SEO.Service.Model;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace SmokeBall.SEO.Service
{
    public class HttpWebClient : IHttpWebClient
    {

        private readonly ILogger _logger;

        public HttpWebClient(ILogger<HttpWebClient> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Returns response from the url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                    {
                        var html = reader.ReadToEnd();
                        //create log
                        _logger.LogInformation("Info:", new HttpRequestLog
                        {
                            Request = request,
                            Url = request.RequestUri.ToString(),
                            Method = request.Method,
                            Response = response.ToString()
                        });
                        return html;
                    }
                    
                }
            }
            catch (Exception ee)
            {
                _logger.LogError("Error:", new HttpErrorLog { Request = request, Url = request.RequestUri.ToString(), ExceptionMessage = ee.ToString() });
                return null;
            }

        }
    }
}
