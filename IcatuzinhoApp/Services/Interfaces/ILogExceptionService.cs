using System;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public interface ILogExceptionService
    {
        Task Save(Transaction transacion, LogExceptionType type, string ExceptionMessage, string InnerExceptionMessage);

        void SubmitToInsights(Exception ex);
    }
}

