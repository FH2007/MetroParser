using AngleSharp.Dom;
using AngleSharp;
using MetroParserApi.Models;
using IConfiguration = AngleSharp.IConfiguration;

namespace MetroParserApi.Services
{
    public static class ScheduleParser
    {
        public static async Task UpdateSchedule()
        {
            var stations = await GetStations();
            foreach (var station in stations)
            {
                UpdateStationSchedule(station);
            }
        }

        private static void UpdateStationSchedule(Station station)
        {
            throw new NotImplementedException();
        }

        private static async Task<Station[]> GetStations()
        {
            Uri[] stationUrls = await GetStationsUrl();
            Station[] stations = new Station[stationUrls.Length];
            for (int i = 0; i < stationUrls.Length; i++)
            {
                stations[i] = ParseStationSchedule(stationUrls[i]);
            }
            return stations;
        }

        private static async Task<Uri[]> GetStationsUrl()
        {
            IConfiguration config = Configuration.Default;

            //Create a new context for evaluating webpages with the given config
            IBrowsingContext context = BrowsingContext.New(config);

            //Parse the document from the content of a response to a virtual request
            IDocument document = await context.OpenAsync(new Url("https://metro-ektb.ru/podrobnye-grafiki-po-stanciyam/"));

            //Do something with document like the following
            Console.WriteLine("Serializing the (original) document:");
            Console.WriteLine(document.DocumentElement.OuterHtml);

            IElement p = document.CreateElement("p");
            p.TextContent = "This is another paragraph.";
            throw new NotImplementedException();
        }

        private static Station ParseStationSchedule(Uri stationUrl)
        {
            throw new NotImplementedException();
        }
    }

}
