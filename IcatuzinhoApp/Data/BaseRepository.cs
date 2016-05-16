using System;

using Microsoft.Practices.Unity;
using Realms;

namespace IcatuzinhoApp
{
    public class BaseRepository
    {
        readonly ILogExceptionService _log;
        public Realm _realm;
        const string salt = "ngNrOqLYqEe1R53acbHa";

        public BaseRepository()
        {
            if (_log == null)
                _log = App._container.Resolve<ILogExceptionService>();

            try
            {
                if (_realm == null)
                    _realm = Realm.GetInstance();
            }
            catch (Exception ex)
            {
                _log.SubmitToInsights(ex);
                UIFunctions.ShowErrorMessageToUI("Encontramos um problema com a sua base de dados, reinstale o aplicativo");
            }
        }

        public void Log(Exception ex) => _log.SubmitToInsights(ex);
    }
}

