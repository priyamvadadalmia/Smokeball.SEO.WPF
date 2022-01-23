using SmokeBall.SEO.Business.Model;
using SmokeBall.SEO.Business.Utility;
using SmokeBall.SEO.Service;
using System.Web;

namespace SmokeBall.SEO.Business
{

    public class SEResult : ISEResult
    {
        private readonly string URL = @"http://www.google.com/search?num=100&q={0}";
        private readonly IHttpWebClient _httpWebCient;
        public SEResult(IHttpWebClient httpWebClient)
        {
            _httpWebCient = httpWebClient;
        }
        /// <summary>
        /// Return Search Result
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public string Search(SearchRequest searchRequest)
        {
            var url = string.Format(URL, HttpUtility.UrlEncode(searchRequest.Keywords));
            var response = _httpWebCient.Get(url);
            return string.Join(",",HtmlScrapper.FindAllMatchingUrlIndex(response, searchRequest.Url));
        }
    }
}
