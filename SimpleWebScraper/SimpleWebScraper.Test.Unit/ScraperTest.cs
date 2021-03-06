using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper.Test.Unit
{
    [TestClass]
    public class ScraperTest
    {
        private readonly Scraper _scraper = new Scraper();

        [TestMethod]
        public void FindCollectionWithNoParts()
        {
            var content = "filler filler <a href=\"http://domain.com\" data-id=\"someId\" " +
                "class=\"result-title hdrlnk\">some text</a> filler filler";

            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .Build();

            var foundElements = _scraper.Scrape(scrapeCriteria);

            Assert.IsTrue(foundElements.Count == 1);
            Assert.IsTrue(foundElements[0] == "<a href=\"http://domain.com\" data-id=\"someId\" " +
                "class=\"result-title hdrlnk\">some text</a>");
        }

        [TestMethod]
        public void FindCollectionWithTwoParts()
        {
            var content = "filler filler <a href=\"http://domain.com\" data-id=\"someId\" " +
                "class=\"result-title hdrlnk\">some text</a> filler filler";

            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .WithParts(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@">(.*?)</a>")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .WithParts(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@"href=\""(.*?)\""")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .Build();

            var foundElements = _scraper.Scrape(scrapeCriteria);

            Assert.IsTrue(foundElements.Count == 2);
            Assert.IsTrue(foundElements[0] == "some text");
            Assert.IsTrue(foundElements[1] == "http://domain.com");
        }
    }
}
