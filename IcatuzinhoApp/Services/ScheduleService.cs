using System;

namespace IcatuzinhoApp
{
    public class ScheduleService : IScheduleService
    {

        #region IBaseService implementation

        public System.Threading.Tasks.Task<bool> InsertOrReplaceAllWithChildrenAsync(System.Collections.Generic.List<Schedule> list)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> DeleteAsync(Schedule entidade)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<Schedule>> GetAllWithChildrenAsync(System.Linq.Expressions.Expression<Func<Schedule, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Schedule> GetAsync(System.Linq.Expressions.Expression<Func<Schedule, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<Schedule>> GetAllWithChildrenAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Schedule> GetWithChildrenByIdAsync(int pkId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> UpdateWithChildrenAsync(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Any()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> InsertOrReplaceWithChildrenAsync(Schedule entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

