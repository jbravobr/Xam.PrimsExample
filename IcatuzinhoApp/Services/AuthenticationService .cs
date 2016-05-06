using System;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public class AuthenticationService : BaseService<AuthenticationToken>, IAuthenticationService
    {
        IHttpAccessService _httpClient;
        ILogExceptionService _log;

        public AuthenticationService(IHttpAccessService httpClient, ILogExceptionService log)
        {
            _httpClient = httpClient;
            _log = log;
        }

        public async Task<bool> DoAuthentication(string username, string password, bool isEncrypted)
        {
            try
            {
                if (!string.IsNullOrEmpty(username) &&
                   !string.IsNullOrEmpty(password))
                {
                    var auth = await _httpClient.AuthenticationWithFormUrlEncoded(username, password, isEncrypted);

                    if (auth != null)
                    {
                        base.InsertOrReplaceWithChildren(auth);
                        return await Task.FromResult(true);
                    }
                }

                return await Task.FromResult(false);

            }
            catch (Exception ex)
            {
                _log.SubmitToInsights(ex);
                UIFunctions.ShowErrorMessageToUI();
                return await Task.FromResult(false);
            }
        }
    }
}

