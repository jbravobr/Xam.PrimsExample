using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IcatuzinhoApp
{
    public class HttpAccessService : IHttpAccessService
    {
        public HttpClient Init()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("labdev.labdevmobile.com.br"),
                Timeout = TimeSpan.FromSeconds(40)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}

