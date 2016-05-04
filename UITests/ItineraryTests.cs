using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IcatuzinhoApp.UITests
{
    [TestFixture]
    public class ItineraryTests
    {
        HttpClient _httpClient = Helpers.ReturnClient();

        [Test]
        public async Task Try_Get_itineraries()
        {
            var listItineraries = new List<Itinerary>();

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await _httpClient.GetAsync($"icatuzinhoapi/api/itinerary/");

            if (result.IsSuccessStatusCode)
            {
                var stringJson = await result.Content.ReadAsStringAsync();
                listItineraries = JsonConvert.DeserializeObject<List<Itinerary>>(stringJson);
            }

            CollectionAssert.AllItemsAreInstancesOfType(listItineraries, typeof(Itinerary));
            CollectionAssert.IsNotEmpty(listItineraries);
            CollectionAssert.AllItemsAreNotNull(listItineraries);
        }
    }
}

