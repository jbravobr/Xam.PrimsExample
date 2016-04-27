using System;

namespace IcatuzinhoApp
{
    public class AuthenticationCodeService : IAuthenticationCodeService
    {
        public AuthenticationCodeService()
            : base()
        {
        }

        #region IBaseService implementation

        public System.Threading.Tasks.Task<bool> InsertOrReplaceAllWithChildrenAsync(System.Collections.Generic.List<AuthenticationCode> list)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> DeleteAsync(AuthenticationCode entidade)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<AuthenticationCode>> GetAllWithChildrenAsync(System.Linq.Expressions.Expression<Func<AuthenticationCode, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<AuthenticationCode> GetAsync(System.Linq.Expressions.Expression<Func<AuthenticationCode, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<AuthenticationCode>> GetAllWithChildrenAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<AuthenticationCode> GetWithChildrenByIdAsync(int pkId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> UpdateWithChildrenAsync(AuthenticationCode entity)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Any()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> InsertOrReplaceWithChildrenAsync(AuthenticationCode entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

