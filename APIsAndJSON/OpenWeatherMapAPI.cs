using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void getWeather()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var key = config.GetConnectionString("OpenWeather");
             var client = new HttpClient();

            //var city = "Santa Rosa";
            Console.WriteLine("Enter a city name to get the weather: ");
            var city = Console.ReadLine();

            var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}&units=imperial";
            var response = client.GetStringAsync(weatherUrl).Result;

            JObject formattedResponse = JObject.Parse(response);
            //Console.WriteLine(formattedResponse.ToString());
            var temp = formattedResponse["main"]["temp"];
            Console.WriteLine($"The current temperature is: {temp} F");
        }
        
    }
}
