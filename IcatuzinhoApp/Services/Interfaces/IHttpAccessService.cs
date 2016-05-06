using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public interface IHttpAccessService
    {
        HttpClient Init(string accessToken = null);
        Task<AuthenticationToken> AuthenticationWithFormUrlEncoded(string username, string password, bool isEncrypted);
    }
}

