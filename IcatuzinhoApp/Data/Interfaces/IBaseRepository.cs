using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace IcatuzinhoApp
{
	public interface IBaseRepository<T>
	{
		Task<bool> InsertOrReplaceAllWithChildrenAsync (IList<T> list);

		Task<bool> DeleteAsync (T entidade);

		Task<List<T>> GetAllWithChildrenAsync (Expression<Func<T, bool>> predicate);

		Task<T> GetAsync (Expression<Func<T,bool>> predicate);

		Task<List<T>> GetAllWithChildrenAsync ();

		Task<T> GetWithChildrenByIdAsync (int pkId);

		Task<bool> UpdateWithChildrenAsync (T entity);

		Task<bool>Any ();

		Task<bool> InsertOrReplaceWithChildrenAsync (T entity);
	}
}

