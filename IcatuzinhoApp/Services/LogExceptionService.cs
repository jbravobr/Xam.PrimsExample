using System;
using System.Threading.Tasks;
using Xamarin;

namespace IcatuzinhoApp
{
    public class LogExceptionService : BaseService<LogException>, ILogExceptionService
    {
        /// <summary>
        /// Efetua o registro local da erro/transação ocorrido.
        /// </summary>
        /// <param name="trasaction">Trasaction.</param>
        /// <param name="type">Type.</param>
        /// <param name="exceptionMessage">Exception message.</param>
        /// <param name="innerExceptionMessage">Inner exception message.</param>
        public async Task Save(Transaction trasaction, LogExceptionType type, string exceptionMessage, string innerExceptionMessage)
        {
            var logEx = new LogException
            {
                Exception = exceptionMessage,
                InnerException = innerExceptionMessage,
                Trasaction = trasaction,
                Type = type
            };

            base.InitiateRepository();
            await base.repository.InsertOrReplaceWithChildrenAsync(logEx);
        }

        /// <summary>
        /// Envia para o Insights o erro (Exception) ocorrido.
        /// </summary>
        /// <param name="ex">Ex.</param>
        public void SubmitToInsights(Exception ex)
        {
            Insights.Report(ex);
        }
    }
}

