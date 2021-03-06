﻿using AngleSharp.Parser.Html;
using NewsAggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace NewsAggregator.Scraper
{
    public class VivaScraper
    {
        private static string RSS = "http://rss.viva.co.id/get/all";
        public static string PostFix = "viva";

        private static void GetContent(News news)
        {
            try
            {
                HtmlParser parser = new HtmlParser();
                WebClient client = new WebClient();

                var document = parser.Parse(client.DownloadString(news.Url));
                var isi = document.All.Where(m => m.LocalName == "span" && m.GetAttribute("itemprop") == "description");

                news.Content = isi.ToArray()[0].TextContent;
            }
            catch
            {
                news.Content = "";
            }
        }

        public static List<News> Scrape()
        {
            List<News> result = RSSScraper.GetTitleAndURL(RSS, PostFix);

            foreach (News news in result)
            {
                GetContent(news);
            }

            return result;
        }
    }
}