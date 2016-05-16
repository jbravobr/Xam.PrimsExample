using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Realms;

namespace IcatuzinhoApp
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private RealmResults<User> _user
        {
            get
            {
                return _realm.All<User>();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public bool Any()
        {
            try
            {
                return _user.Any();
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }

        }

        /// <summary>
        /// Deleta uma instância da entidade principal.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public bool Delete(User entity)
        {
            try
            {
                if (_user.Any(x => x.Id == entity.Id))
                {
                    using (var tran = _realm.BeginWrite())
                    {
                        _realm.Remove(_user.First(x => x.Id == entity.Id));
                        tran.Commit();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }

        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public User Get()
        {
            try
            {
                return _user.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }

        }

        /// <summary>
        /// Retorna uma instância da entidade principal usando um filtro (predicado).
        /// </summary>
        /// <param name="predicate">Filtro</param>
        public User Get(Expression<Func<User, bool>> predicate)
        {
            try
            {
                return _user.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }

        }

        /// <summary>
        /// Retorna todas as instâncias da entidade principal.
        /// </summary>
        public List<User> GetAll()
        {
            try
            {
                return _user.ToList();
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }

        }

        /// <summary>
        /// Retorna todas as intâncias da entidade principal usando um filtro (predicado).
        /// </summary>
        /// <param name="predicate">Predicado</param>
        public List<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            try
            {
                return _user.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }

        }

        /// <summary>
        /// Retorna uma instância da entidade principal buscando só pelo ID.
        /// </summary>
        public User GetById(int pkId)
        {
            try
            {
                return _user.FirstOrDefault(x => x.Id == pkId);
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }

        }

        /// <summary>
        /// Insere um novo registro na entidade principal.
        /// </summary>
        public bool Insert(User entity)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<User>();
                    obj = entity;

                    tran.Commit();
                }
                catch (RealmException rEx)
                {
                    Log(rEx);
                    return false;
                }
                catch (Exception ex)
                {
                    Log(ex);
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Insere uma lista de novos registros na entidade principal.
        /// </summary>
        public bool Insert(List<User> entities)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<User>();

                    foreach (var entity in entities)
                    {
                        obj = entity;
                        tran.Commit();
                    }
                }
                catch (RealmException rEx)
                {
                    Log(rEx);
                    return false;
                }
                catch (Exception ex)
                {
                    Log(ex);
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Atualizar uma instância da entidade principal.
        /// </summary>
        public bool Update(User entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _user.First(x => x.Id == entity.Id);
                    obj = entity;

                    tran.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }

        }
    }
}

