using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper
{
    class Program
    {
        private const string Method = "search";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter city to scrape info from:");
                var craigslistCity = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Please enter the CraigsList category to scrape:");
                var craigslistCategoryName = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString(
                        $"https://{craigslistCity.Replace(" ", string.Empty)}" +
                        $".craigslist.org/{Method}/{craigslistCategoryName}");

                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                        .WithData(content)
                        .WithRegex(
                            @"<a href=\""(.*?)\"" data-id=\""(.*?)\"" 
                            class=\""result-title hdrlnk\"" id=\""(.*?)\"" >(.*?)</a>")
                        .WithRegexOption(RegexOptions.ExplicitCapture)
                        .WithParts(
                            new ScrapeCriteriaPartBuilder()
                                .WithRegex(@">(.*?)</a>")
                                .WithRegexOption(RegexOptions.Singleline)
                                .Build())
                        .WithParts(
                            new ScrapeCriteriaPartBuilder()
                                .WithRegex(@"href=\""(.*?)\""")
                                .WithRegexOption(RegexOptions.Singleline)
                                .Build())
                        .Build();

                    Scraper scraper = new Scraper();

                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if (scrapedElements.Any())
                    {
                        foreach (var scrapedElement in scrapedElements)
                        {
                            Console.WriteLine(scrapedElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There were no matches for the specified scrape criteria.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
