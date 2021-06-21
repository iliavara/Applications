using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp8
{
    [XmlRoot(ElementName = "rss")]
    public class RSS
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "item")]
        public Item Item { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
    }

    class Program
    {
        public static (decimal currencyAmount, decimal gelAmount) GetCurrency(string currencyCode, string currencies)
        {
            var pattern = new Regex($@"{currencyCode}<\/td>(\s*)<td>.*<\/td>(\s*)<td>.*<\/td>");
            var match = pattern.Match(currencies);

            var values = match.Value.Split(new string[] { "<td>", "</td>" }, StringSplitOptions.RemoveEmptyEntries).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            var currencyAmount = decimal.Parse(values[1].Split(" ")[0]);
            var gelAmount = decimal.Parse(values[2]);

            return (currencyAmount, gelAmount);
        }

        public static string ExchangeRate(string from, string to)
        {
            using (var client = new HttpClient())
            {
                var data = client.GetStringAsync("http://www.nbg.ge/rss.php?fbclid=IwAR0d1_SVPoDz7gNGCNKb3nH91XaUiUzBCfm2aQpTNz9V3ehRvlkjiNw8FMc").Result;

                var reader = new StringReader(data);
                var serializer = new XmlSerializer(typeof(RSS));
                var rss = (RSS)serializer.Deserialize(reader);

                var fromCurrency = GetCurrency(from, rss.Channel.Item.Description);
                var toCurrency = GetCurrency(to, rss.Channel.Item.Description);

                var rate = toCurrency.currencyAmount / (toCurrency.gelAmount / fromCurrency.gelAmount);

                return $"{fromCurrency.currencyAmount} {from} - {Math.Round(rate, 4)} {to}";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ExchangeRate("USD", "EUR"));
        }
    }
}