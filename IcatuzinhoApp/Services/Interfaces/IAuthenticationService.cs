using System;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public interface IAuthenticationService : IBaseService<AuthenticationToken>
    {
        Task<bool> DoAuthentication(string username, string password, bool isEncrypted);
    }
}

