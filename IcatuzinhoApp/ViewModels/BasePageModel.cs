using System;
using Prism.Mvvm;

namespace IcatuzinhoApp
{
    public class BasePageViewModel : BindableBase
    {
        ILogExceptionService _logExceptionService;

        public void SendToInsights(Exception ex)
        {
            _logExceptionService = FreshMvvm.FreshIOC.Container.Resolve<ILogExceptionService>();
            _logExceptionService.SubmitToInsights(ex);
        }

        public void RecordMetric(Transaction transaction, LogExceptionType type, Exception ex)
        {
            _logExceptionService = FreshMvvm.FreshIOC.Container.Resolve<ILogExceptionService>();
            _logExceptionService.Save(transaction, type, ex?.Message, ex.InnerException?.InnerException.Message);
        }
    }
}

