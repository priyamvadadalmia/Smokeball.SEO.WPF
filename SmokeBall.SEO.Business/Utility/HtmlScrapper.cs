using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SmokeBall.SEO.Business.Utility
{
    public static class HtmlScrapper
    {
        /// <summary>
        /// Examines the search result and retrieves the positions.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<string> FindAllMatchingUrlIndex(string html, string url)
        {
            var response = new List<string>();
            string lookup = "(?<=url\\?q=)[^&]*";
            MatchCollection matches = Regex.Matches(html, lookup);
            Predicate<Match> match = item => item.Groups[0].Value.Contains(url);

            for (int index = matches.ToList().FindIndex(match); index > -1; index = matches.ToList().FindIndex(index + 1, match))
            {
                response.Add((index +1).ToString());
            }

            return response;
        }
    }
}
