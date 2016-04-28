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
    public class StationTests
    {
        HttpClient _httpClient = Helpers.ReturnClient();

        [Test]
        public async Task Try_Get_Stations()
        {
            var listStation = new List<Station>();

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await _httpClient.GetAsync($"icatuzinhoapi/api/station/");

            if (result.IsSuccessStatusCode)
            {
                var stringJson = await result.Content.ReadAsStringAsync();
                listStation = JsonConvert.DeserializeObject<List<Station>>(stringJson);
            }

            CollectionAssert.AllItemsAreInstancesOfType(listStation, typeof(Station));
            CollectionAssert.IsNotEmpty(listStation);
            CollectionAssert.AllItemsAreNotNull(listStation);
        }
    }
}

