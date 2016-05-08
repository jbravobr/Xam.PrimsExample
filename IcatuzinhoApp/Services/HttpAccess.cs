using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Acr.UserDialogs;

namespace IcatuzinhoApp
{
    public class HttpAccessService : IHttpAccessService
    {
        readonly ILogExceptionService _log;
        readonly IUserDialogs _userDialogs;

        public HttpAccessService(ILogExceptionService log,
                                 IUserDialogs userDialogs)
        {
            _log = log;
            _userDialogs = userDialogs;
        }

        public HttpClient Init(string accessToken = null)
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri($"{Constants.BaseAddress}"),
                    Timeout = TimeSpan.FromSeconds(40)
                };

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(accessToken))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                return httpClient;
            }
            catch (Exception ex)
            {
                _log.SubmitToInsights(ex);
                UIFunctions.ShowErrorMessageToUI();
                return null;
            }
        }
    }
}

