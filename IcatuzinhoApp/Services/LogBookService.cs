using System;

namespace IcatuzinhoApp
{
    public class LogBookService : ILogExceptionService
    {
        public LogBookService()
            : base()
        {
        }

        #region ILogExceptionService implementation

        public System.Threading.Tasks.Task Save(Transaction transacion, LogExceptionType type, string ExceptionMessage, string InnerExceptionMessage)
        {
            throw new NotImplementedException();
        }

        public void SubmitToInsights(Exception ex)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

