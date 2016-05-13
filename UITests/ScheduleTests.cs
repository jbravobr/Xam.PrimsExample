﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Moq;

namespace IcatuzinhoApp.UITests
{
    [TestFixture]
    public class ScheduleTests
    {
        HttpClient _httpClient;
        Mock<IScheduleService> mock;

        [SetUp]
        public void SetUp()
        {
            mock = new Mock<IScheduleService>();
        }

        [Test]
        public async Task ReturnListSchedulesFromAPI()
        {
            var listSchedule = new List<Schedule>();
            var token = await Helpers.GenerateTokenAuthentication();

            _httpClient = Helpers.ReturnClient(token);

            var result = await _httpClient.GetAsync(Constants.ScheduleServiceAddress);

            if (result.IsSuccessStatusCode)
            {
                var stringJson = await result.Content.ReadAsStringAsync();
                listSchedule = JsonConvert.DeserializeObject<List<Schedule>>(stringJson);
            }

            CollectionAssert.IsNotEmpty(listSchedule);
            CollectionAssert.AllItemsAreNotNull(listSchedule);
        }

        [Test]
        public void PopulateScheduleTable()
        {
            var schedules = new List<Schedule>
            {
                new Schedule{StartSchedule = DateTime.Now.ToShortTimeString(),Id = 1, Message = "Teste 1"},
                new Schedule{StartSchedule = DateTime.Now.AddHours(1).ToShortTimeString(),Id = 2, Message = "Teste 2"},
                new Schedule{StartSchedule = DateTime.Now.AddHours(2).ToShortTimeString(),Id = 3, Message = "Teste 3"},
                new Schedule{StartSchedule = DateTime.Now.AddHours(3).ToShortTimeString(),Id = 4, Message = "Teste 4"},
                new Schedule{StartSchedule = DateTime.Now.AddHours(4).ToShortTimeString(),Id = 5, Message = "Teste 5"}
            };

            mock.Setup(m => m.GetAll()).Returns(schedules);
            var scheduleService = mock.Object;
            var col = scheduleService.GetAll();

            Assert.GreaterOrEqual(col.Count, 0);
        }
    }
}

