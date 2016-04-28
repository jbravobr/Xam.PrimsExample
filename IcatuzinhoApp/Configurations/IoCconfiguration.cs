using System;

namespace IcatuzinhoApp
{
    public class IoCconfiguration
    {
        public static void Init()
        {
            // Registrando Serviços e dependências.
            FreshMvvm.FreshIOC.Container.Register<IUserService, UserService>();
            FreshMvvm.FreshIOC.Container.Register<IHttpAccessService, HttpAccessService>();
            FreshMvvm.FreshIOC.Container.Register<IAuthenticationCodeService, AuthenticationCodeService>();
            FreshMvvm.FreshIOC.Container.Register<IDriveService, DriverService>();
            FreshMvvm.FreshIOC.Container.Register<ILogExceptionService, LogExceptionService>();
            FreshMvvm.FreshIOC.Container.Register<IScheduleService, ScheduleService>();
            FreshMvvm.FreshIOC.Container.Register<IStationService, StationService>();
            FreshMvvm.FreshIOC.Container.Register<ITransactionService, TransactionService>();
            FreshMvvm.FreshIOC.Container.Register<ITravelService, TravelService>();
            FreshMvvm.FreshIOC.Container.Register<IUserService, UserService>();
            FreshMvvm.FreshIOC.Container.Register<IVehicleService, VehicleService>();
            FreshMvvm.FreshIOC.Container.Register<IWeatherService, WeatherService>();
        }
    }
}

