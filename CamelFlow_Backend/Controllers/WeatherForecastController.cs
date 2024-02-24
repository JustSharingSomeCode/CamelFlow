using CamelFlow_Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CamelFlow_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("DynamicTest")]
        public async Task<IActionResult> DynamicTest()
        {
            var testFormJson = "[\r\n        {\r\n            \"Name\": \"Name\",\r\n            \"Type\": \"text\",\r\n            \"Options\": null,\r\n            \"ListItemDefinition\": null\r\n        },\r\n        {\r\n            \"Name\": \"Age\",\r\n            \"Type\": \"number\",\r\n            \"Options\": null,\r\n            \"ListItemDefinition\": null\r\n        },\r\n        {\r\n            \"Name\": \"Products\",\r\n            \"Type\": \"list\",\r\n            \"Options\": null,\r\n            \"DataSource\": null,\r\n            \"ListItemDefinition\": [\r\n                {\r\n                    \"Name\": \"Name\",\r\n                    \"Type\": \"text\",\r\n                    \"Options\": null\r\n                },\r\n                {\r\n                    \"Name\": \"Quantity\",\r\n                    \"Type\": \"select\",\r\n                    \"Options\": \"1,2,3,4,5,6,7,8,9\"\r\n                },\r\n                {\r\n                    \"Name\": \"Unitary Price\",\r\n                    \"Type\": \"number\",\r\n                    \"Options\": null\r\n                }\r\n            ]\r\n        }\r\n    ]";

            var json = "{\r\n    \"Name\": \"Oscar\",\r\n    \"Age\": \"21\",\r\n    \"Products\": [\r\n        {\r\n            \"Name\": \"Rtx 3060\",\r\n            \"Quantity\": \"1\",\r\n            \"Unitary Price\": \"2400000\"\r\n        },\r\n        {\r\n            \"Name\": \"Intel i5-10600KF\",\r\n            \"Quantity\": \"1\",\r\n            \"Unitary Price\": \"800000\"\r\n        },\r\n        {\r\n            \"Name\": \"Ram 8GB\",\r\n            \"Quantity\": \"2\",\r\n            \"Unitary Price\": \"160000\"\r\n        }\r\n    ]\r\n}";

            dynamic convertedJson = JsonConvert.DeserializeObject<dynamic>(json) ?? throw new Exception("JSON convert returned null");
            var convertedFormJson = JsonConvert.DeserializeObject<ItemDefinition[]>(testFormJson) ?? throw new Exception("JSON convert returned null");

            //foreach ( var item in convertedFormJson )
            //{
            //    if (convertedJson[item.Name] == null)
            //    {
            //        return BadRequest($"Missing item {item.Name}");
            //    }
            //}

            if (!ValidateStructure(convertedFormJson, convertedJson))
            {
                return BadRequest("Missing items in structure");
            }

            var name = convertedJson.Name;
            var age = convertedJson.Age;
            var products = convertedJson.Products;
            //var test = convertedJson.test;

            return Ok(products);
        }

        /// <summary>
        /// Validates the structure of the answers with the provided definitions
        /// </summary>
        /// <param name="itemsDefinition">The structure of the objects provided in the json</param>
        /// <param name="json">The json object to be validated (IT MUST BE A JSON OBJECT!!!)</param>
        /// <returns></returns>
        private bool ValidateStructure(ItemDefinition[] itemsDefinition, dynamic json)
        {
            foreach (var item in itemsDefinition)
            {
                if (json[item.Name] == null)
                {
                    return false;
                }
                else if(item.Type == ItemDefinitionTypes.List)
                {
                    foreach (var itemTest in json[item.Name])
                    {
                        if(!ValidateStructure(item.ListItemDefinition, itemTest))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
