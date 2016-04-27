using System;

namespace IcatuzinhoApp
{
    public class IoCconfiguration
    {
        public static void Init()
        {
            // Registrando Serviços e dependências.
            FreshMvvm.FreshIOC.Container.Register<IUserService,UserService>();
        }
    }
}

