using System;
using Autofac;

namespace IcatuzinhoApp
{
	public class AutoFacConfig
	{
		public static IContainer Init()
		{
			var builder = new ContainerBuilder();

			// Registrando Serviços e dependências.
			//builder.RegisterInstance (new LogExceptionService ()).As<ILogExceptionService> ();

			// Registrando ViewModels.
			//builder.RegisterType<RootViewModel>();

			return builder.Build();
		}
	}
}

