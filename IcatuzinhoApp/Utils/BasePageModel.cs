using System;
namespace IcatuzinhoApp
{
    public class BasePageModel : FreshMvvm.FreshBasePageModel
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
            _logExceptionService.Save(transaction, type, ex.Message, ex.InnerException?.InnerException.Message);
        }
    }
}

