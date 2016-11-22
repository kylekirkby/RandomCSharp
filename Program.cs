using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication1
{
    class GatherData
    {
        public const string url = "http://apis.is/earthquake/is";
        public const string root = "results";

        public GatherData()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(url);
                //Gather the Json for the earthquakes.

                var root = JObject.Parse(json);
                var serializer = new JsonSerializer();
                var expectedUserObject = serializer.Deserialize<JArray>(root["results"].CreateReader());

                foreach (JObject pair in expectedUserObject)
                {
                    string timestamp = pair.Value<string>("timestamp");
                    string latitude = pair.Value<string>("latitude");
                    string longitude = pair.Value<string>("longitude");
                    string depth = pair.Value<string>("depth");
                    string size = pair.Value<string>("size");
                    string quality = pair.Value<string>("quality");
                    string location = pair.Value<string>("humanReadableLocation");

                    Console.WriteLine("----------------------");
                    Console.WriteLine("Time: " + timestamp);
                    Console.WriteLine("Location: " + location);
                    Console.WriteLine("Magnitude: " + size);
                    Console.WriteLine("----------------------");
                }
            }
        }
    }
    class Program
    {
        public const string url = "http://apis.is/earthquake/is";
        static void Main(string[] args)
        {
            var jsonGatherer = new GatherData();

        }
    }
}
