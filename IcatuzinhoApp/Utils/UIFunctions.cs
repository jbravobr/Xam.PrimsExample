﻿using Microsoft.Practices.Unity;
using Acr.UserDialogs;
using Softweb.Controls;

namespace IcatuzinhoApp
{
    public static class UIFunctions
    {
        static IUserDialogs _userDialogs;

        public static void ShowErrorMessageToUI()
        {
            _userDialogs = App._container.Resolve<IUserDialogs>();
            _userDialogs.Alert(new AlertConfig
            {
                Message = "Desculpe, houve um erro na aplicação. Por favor tente novamente",
                OkText = "OK",
                Title = "Erro"
            });
        }

        public static void ShowErrorMessageToUI(string message)
        {
            _userDialogs = App._container.Resolve<IUserDialogs>();
            _userDialogs.Alert(new AlertConfig
            {
                Message = message,
                OkText = "OK"
            });
        }

        public static void ShowErrorForConnectivityMessageToUI()
        {
            _userDialogs = App._container.Resolve<IUserDialogs>();
            _userDialogs.Alert(new AlertConfig
            {
                Message = "Desculpe, você precisa estar conectado a internet para usar este aplicativo",
                OkText = "OK",
                Title = "Erro"
            });
        }

        public static void ShowToastErrorMessageToUI(string message, int timeout = 3000)
        {
            //UIMessage.ShowToast(message,
        }

        public static void ShowToastWarningMessageToUI(string message, int timeout = 3000)
        {
            _userDialogs = App._container.Resolve<IUserDialogs>();
            _userDialogs.WarnToast(message, string.Empty, timeout);
        }

        public static void ShowToastInfoMessageToUI(string message, int timeout = 3000)
        {
            _userDialogs = App._container.Resolve<IUserDialogs>();
            _userDialogs.InfoToast(message, string.Empty, timeout);
        }

        public static void ShowToastSuccessMessageToUI(string message, int timeout = 3000)
        {
            _userDialogs = App._container.Resolve<IUserDialogs>();
            _userDialogs.SuccessToast(message, string.Empty, timeout);
        }

        public static void ShowToastToUI(string message, int timeout = 3000)
        {
            _userDialogs = App._container.Resolve<IUserDialogs>();

            var toastConfig = new ToastConfig(new ToastEvent(), message, string.Empty);
            _userDialogs.Toast(toastConfig);
        }
    }
}

