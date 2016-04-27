using System;
using System.Net.Http;

namespace IcatuzinhoApp
{
    public interface IHttpAccessService
    {
        HttpClient Init();
    }
}

