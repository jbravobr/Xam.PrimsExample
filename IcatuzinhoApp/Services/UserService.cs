using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace IcatuzinhoApp
{
    public class UserService : BaseService<User>, IUserService
    {
        IHttpAccessService _httpService;
        Utils<User> _utils;

        public UserService(IHttpAccessService httpService)
        {
            _httpService = httpService;
        }

        public async Task<bool> GetAuthenticatedUser()
        {
            var resultDB = false;

            try
            {
                var user = GetAllWithChildren().FirstOrDefault();

                if (user != null)
                    resultDB = await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return await Task.FromResult(resultDB);
            }

            return await Task.FromResult(resultDB);
        }

        public async Task<bool> Login(string email, string password)
        {
            var resultDB = false;

            try
            {
                var clientCaller = _httpService.Init();
                var data = await clientCaller.GetAsync($"{Constants.UserServiceAddress}{email}/{password}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    _utils = new Utils<User>();
                    var user = await _utils.ConvertSingleObjectFromJson(data.Content);

                    if (user != null)
                        resultDB = InsertOrReplaceWithChildren(user);

                    return resultDB;
                }

            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
            }

            return resultDB;
        }


    }
}

