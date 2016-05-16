using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Realms;

namespace IcatuzinhoApp
{
    public class AuthenticationRepository : BaseRepository, IAuthenticationRepository
    {
        private RealmResults<AuthenticationToken> _authToken
        {
            get
            {
                return _realm.All<AuthenticationToken>();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public bool Any()
        {
            try
            {
                return _authToken.Any();
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
        public bool Delete(AuthenticationToken entity)
        {
            try
            {
                if (_authToken.Any(x => x.Id == entity.Id))
                {
                    using (var tran = _realm.BeginWrite())
                    {
                        _realm.Remove(_authToken.First(x => x.Id == entity.Id));
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
        public AuthenticationToken Get()
        {
            try
            {
                return _authToken.FirstOrDefault();
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
        public AuthenticationToken Get(Expression<Func<AuthenticationToken, bool>> predicate)
        {
            try
            {
                return _authToken.FirstOrDefault(predicate);
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
        public List<AuthenticationToken> GetAll()
        {
            try
            {
                return _authToken.ToList();
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
        public List<AuthenticationToken> GetAll(Expression<Func<AuthenticationToken, bool>> predicate)
        {
            try
            {
                return _authToken.Where(predicate).ToList();
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
        public AuthenticationToken GetById(int pkId)
        {
            try
            {
                return _authToken.FirstOrDefault(x => x.Id == pkId);
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
        public bool Insert(AuthenticationToken entity)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<AuthenticationToken>();
                    obj = entity;

                    tran.Commit();
                    var token = Get();
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
        public bool Insert(List<AuthenticationToken> entities)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<AuthenticationToken>();

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
        public bool Update(AuthenticationToken entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _authToken.First(x => x.Id == entity.Id);
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

