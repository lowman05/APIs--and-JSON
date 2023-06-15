using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new HttpClient();

            var quote = new RonVSKanyeAPI(client);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye: {quote.YeQuote()}");

                Console.WriteLine($"Ron: {quote.SwansonQuote()}");
            }

            var localWeather = new OpenWeatherMapAPI(client);

            Console.WriteLine($"The current temperature in {localWeather.CityName()}, Texas is {localWeather.CollegeStationTemp()} degrees." +
                $" Sunrise is at {localWeather.Sunrise()}, and Sunset is at {localWeather.Sunset()}.");









        }
    }
}
