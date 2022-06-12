using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Homework64_Scraper.Data
{
    public class OorahScraper
    {
        public List<OorahPrize> Scrape()
        {
            return ParseOorahHtml(GetOorahHtml());
        }
        private static string GetOorahHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };
            using var client = new HttpClient(handler);
            var url = $"https://www.oorahauction.org/";
            var html = client.GetStringAsync(url).Result;
            return html;
        }
        public static List<OorahPrize> ParseOorahHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var resultDivs = document.QuerySelectorAll(".portfolio-item");
            var prizes = new List<OorahPrize>();
            foreach(var div in resultDivs)
            {
                var prize = new OorahPrize();

                var titleSpan = div.QuerySelector(".portfolio-caption h4");             
                if(titleSpan != null)
                {
                    prize.Title = titleSpan.TextContent;
                }

                var winnerSpan = div.QuerySelector(".portfolio-caption p"); 
                if(winnerSpan != null)
                {
                    prize.Winner = winnerSpan.TextContent;
                }

                var imageTag = div.QuerySelector(".img-responsive");
                if(imageTag != null)
                {
                    prize.ImageUrl = $"https://www.oorahauction.org/{imageTag.Attributes["src"].Value}";
                }

                prizes.Add(prize);
            }
            return prizes;
        }    
    }
}
