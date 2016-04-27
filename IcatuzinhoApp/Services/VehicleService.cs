using System;

namespace IcatuzinhoApp
{
    public class VehicleService : IVehicleService
    {
        public VehicleService()
            : base()
        {
        }

        #region IBaseService implementation

        public System.Threading.Tasks.Task<bool> InsertOrReplaceAllWithChildrenAsync(System.Collections.Generic.List<Vehicle> list)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> DeleteAsync(Vehicle entidade)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<Vehicle>> GetAllWithChildrenAsync(System.Linq.Expressions.Expression<Func<Vehicle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Vehicle> GetAsync(System.Linq.Expressions.Expression<Func<Vehicle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<Vehicle>> GetAllWithChildrenAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Vehicle> GetWithChildrenByIdAsync(int pkId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> UpdateWithChildrenAsync(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Any()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> InsertOrReplaceWithChildrenAsync(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

