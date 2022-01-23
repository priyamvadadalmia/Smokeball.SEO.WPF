using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmokeBall.SEO.Business;
using SmokeBall.SEO.Business.Model;
using SmokeBall.SEO.Business.Utility;
using SmokeBall.SEO.Service;
using System.Collections.Generic;
using Xunit;

namespace SmokeBall.SEO.Test
{
    [TestClass]
    public class GetSearchResultUnitTests
    {
        private readonly Mock<ILogger> _logger;
        private readonly Mock<HttpWebClient> _httpWebClient;
        private readonly Mock<SEResult> _seResult;

        public GetSearchResultUnitTests()
        {
            _logger = new Mock<ILogger>();
            _httpWebClient = new Mock<HttpWebClient>();
            _seResult = new Mock<SEResult>();
        }

        [Fact]
        public void GetSearchResult_SearchMatch_ResultReturned()
        {
            //arrange
            var html = GetHtmlWithSearchData();
            var url = "www.smokeball.com.au";
            //act
            var actionResult = HtmlScrapper.FindAllMatchingUrlIndex(html, url);
            //assert
            Xunit.Assert.IsType<List<string>>(actionResult);
            Xunit.Assert.Equal(new List<string>() { "1" }, actionResult);
        }

        [Fact]
        public void GetSearchResult_NoResult_ResultReturned()
        {
            //arrange
            var html = GetHtmlWithNoSearchData();
            var url = "www.smokeball.com.au";
            //act
            var actionResult = HtmlScrapper.FindAllMatchingUrlIndex(html, url);
            //assert
            Xunit.Assert.IsType<List<string>>(actionResult);
            Xunit.Assert.Equal(new List<string>(), actionResult);
        }

        [Fact]
        public void GetSearchResult_MultipleResultMath_ResultReturned()
        {
            //arrange
            var html = GetHtmlWithMultipleSearchData();
            var url = "www.smokeball.com.au";
            //act
            var actionResult = HtmlScrapper.FindAllMatchingUrlIndex(html, url);
            //assert
            Xunit.Assert.IsType<List<string>>(actionResult);
            Xunit.Assert.Equal(new List<string>() { "1","3" }, actionResult);
        }
        public string GetHtmlWithSearchData()
        {
            return @"<url?q=https://www.smokeball.com.au/practice-area/conveyancing-software&amp;>";
        }
        public string GetHtmlWithNoSearchData()
        {
            return @"<url?q=https://www.smkeball.com.au/practice-area/conveyancing-software&amp;";
        }
        public string GetHtmlWithMultipleSearchData() //Match at 1st and 3rd position
        {
            return @"<url?q=https://www.smokeball.com.au/practice-area/conveyancing-software&amp;><url?q=https://www.smkeball.com.au/practice-area/conveyancing-software&amp;><url?q=https://www.smokeball.com.au/practice-area/conveyancing-software&amp;>";
        }
    }
}
