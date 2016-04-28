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
    public class ScheduleTests
    {
        HttpClient _httpClient = Helpers.ReturnClient();

        [Test]
        public async Task Try_Return_List_Schedules()
        {
            var listSchedule = new List<Schedule>();

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await _httpClient.GetAsync($"icatuzinhoapi/api/schedule");

            if (result.IsSuccessStatusCode)
            {
                var stringJson = await result.Content.ReadAsStringAsync();
                listSchedule = JsonConvert.DeserializeObject<List<Schedule>>(stringJson);
            }

            CollectionAssert.AllItemsAreInstancesOfType(listSchedule, typeof(Schedule));
            CollectionAssert.IsNotEmpty(listSchedule);
            CollectionAssert.AllItemsAreNotNull(listSchedule);
        }
    }
}

