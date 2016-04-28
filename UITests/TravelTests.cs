using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IcatuzinhoApp.UITests
{
    [TestFixture]
    public class TravelTest
    {
        HttpClient _httpClient = Helpers.ReturnClient();

        [Test]
        public async Task Try_Get_Travels()
        {
            var travel = new Travel();

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await _httpClient.GetAsync($"icatuzinhoapi/api/travel/1");

            if (result.IsSuccessStatusCode)
            {
                var stringJson = await result.Content.ReadAsStringAsync();
                travel = JsonConvert.DeserializeObject<Travel>(stringJson);
            }

            Assert.IsInstanceOf(typeof(Travel), travel);
            Assert.NotNull(travel);
        }
    }
}

