using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public class UserService : IUserService
    {
        #region IBaseService implementation

        public Task<bool> InsertOrReplaceAllWithChildrenAsync(List<User> list)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(User entidade)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllWithChildrenAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllWithChildrenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetWithChildrenByIdAsync(int pkId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWithChildrenAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Any()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertOrReplaceWithChildrenAsync(User entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

