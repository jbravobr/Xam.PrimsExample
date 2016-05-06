using System;
using Acr.UserDialogs;

namespace IcatuzinhoApp
{
    public static class UIFunctions
    {
        private static IUserDialogs _userDialogs;

        public static void ShowErrorMessageToUI()
        {
            _userDialogs = FreshMvvm.FreshIOC.Container.Resolve<IUserDialogs>();

            _userDialogs.Alert(new AlertConfig
            {
                Message = "Desculpe, houve um erro na aplicação. Por favor tente novamente",
                OkText = "OK",
                Title = "Erro"
            });
        }
    }
}

