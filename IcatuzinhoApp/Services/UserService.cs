using System;

namespace IcatuzinhoApp
{
    public class UserService : IUserService
    {
        public UserService()
            : base()
        {
        }

        #region IBaseService implementation

        public System.Threading.Tasks.Task<bool> InsertOrReplaceAllWithChildrenAsync(System.Collections.Generic.List<User> list)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> DeleteAsync(User entidade)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<User>> GetAllWithChildrenAsync(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<User> GetAsync(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<User>> GetAllWithChildrenAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<User> GetWithChildrenByIdAsync(int pkId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> UpdateWithChildrenAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Any()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> InsertOrReplaceWithChildrenAsync(User entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

