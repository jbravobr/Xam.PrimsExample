using System;

namespace IcatuzinhoApp
{
    public class TransactionService : ITransactionService
    {
        public TransactionService()
            : base()
        {
        }

        #region IBaseService implementation

        public System.Threading.Tasks.Task<bool> InsertOrReplaceAllWithChildrenAsync(System.Collections.Generic.List<Transaction> list)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> DeleteAsync(Transaction entidade)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<Transaction>> GetAllWithChildrenAsync(System.Linq.Expressions.Expression<Func<Transaction, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Transaction> GetAsync(System.Linq.Expressions.Expression<Func<Transaction, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<Transaction>> GetAllWithChildrenAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Transaction> GetWithChildrenByIdAsync(int pkId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> UpdateWithChildrenAsync(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Any()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> InsertOrReplaceWithChildrenAsync(Transaction entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

