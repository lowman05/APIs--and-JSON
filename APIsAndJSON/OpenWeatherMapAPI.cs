using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        private HttpClient _client;

        public OpenWeatherMapAPI(HttpClient client)
        {
            _client = client;
        }
        public double CollegeStationTemp()
        {
            var apiKeyObj = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey");
            string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q=College%20Station&appid={apiKey}&units=imperial";
            var weatherResponse = _client.GetStringAsync(weatherURL).Result;
            var weatherTemp = JObject.Parse(weatherResponse);
            double temp = (double)weatherTemp["main"]["temp"];
            return temp;                                               
        }
        public string CityName()
        {
            var apiKeyObj = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey");
            string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q=College%20Station&appid={apiKey}&units=imperial";
            var weatherResponse = _client.GetStringAsync(weatherURL).Result;
            var cityName = JObject.Parse(weatherResponse).GetValue("name").ToString();
            return cityName;            
        }
        public string Sunrise()
        {
            var apiKeyObj = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey");
            string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q=College%20Station&appid={apiKey}&units=imperial";
            var weatherResponse = _client.GetStringAsync(weatherURL).Result;
            var sunrise = JObject.Parse(weatherResponse);
            long newSunrise = (long)sunrise["sys"]["sunrise"];
            DateTimeOffset actualSunrise = DateTimeOffset.FromUnixTimeSeconds(newSunrise);
            DateTime dateTime = actualSunrise.LocalDateTime;
            string time = dateTime.ToString("hh:mm tt");
            return time;         
        }
        public string Sunset()
        {
            var apiKeyObj = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey");
            string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q=College%20Station&appid={apiKey}&units=imperial";
            var weatherResponse = _client.GetStringAsync(weatherURL).Result;
            var sunset = JObject.Parse(weatherResponse);
            long newSunset = (long)sunset["sys"]["sunset"];
            DateTimeOffset actualSunset = DateTimeOffset.FromUnixTimeSeconds(newSunset);
            DateTime dateTime = actualSunset.LocalDateTime;
            string time = dateTime.ToString("hh:mm tt");
            return time;
        } 
        


    }
}
