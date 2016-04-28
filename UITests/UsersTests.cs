using NUnit.Framework.Internal;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IcatuzinhoApp.UITests
{
    [TestFixture]
    public class UsersTests
    {
        HttpClient _httpClient = Helpers.ReturnClient();

        [Test]
        public async Task Try_Authenticate_User()
        {
            var userEmail = "ramaral@icatuseguros.com.br";
            var userPassword = "123";
            var user = new User();

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await _httpClient.GetAsync($"icatuzinhoapi/api/user/{userEmail}/{userPassword}");

            if (result.IsSuccessStatusCode)
            {
                var stringJson = await result.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(stringJson);
                Assert.AreEqual(user.Email, userEmail);
            }
            else
                Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.InternalServerError, "Erro na API");

        }
    }
}

