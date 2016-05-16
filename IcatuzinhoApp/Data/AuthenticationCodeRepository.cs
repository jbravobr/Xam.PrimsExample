using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Realms;

namespace IcatuzinhoApp
{
    public class AuthenticationCodeRepository: BaseRepository, IAuthenticationCodeRepository
    {
        private RealmResults<AuthenticationCode> _authCode
        {
            get
            {
                return _realm.All<AuthenticationCode>();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public bool Any()
        {
            try
            {
                return _authCode.Any();
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }
            finally
            {
                _realm.Dispose();
            }
        }

        /// <summary>
        /// Deleta uma instância da entidade principal.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public bool Delete(AuthenticationCode entity)
        {
            try
            {
                if (_authCode.Any(x => x.Id == entity.Id))
                {
                    using (var tran = _realm.BeginWrite())
                    {
                        _realm.Remove(_authCode.First(x => x.Id == entity.Id));
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
            finally
            {
                _realm.Dispose();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public AuthenticationCode Get()
        {
            try
            {
                return _authCode.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }
            finally
            {
                _realm.Dispose();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal usando um filtro (predicado).
        /// </summary>
        /// <param name="predicate">Filtro</param>
        public AuthenticationCode Get(Expression<Func<AuthenticationCode, bool>> predicate)
        {
            try
            {
                return _authCode.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }
            finally
            {
                _realm.Dispose();
            }
        }

        /// <summary>
        /// Retorna todas as instâncias da entidade principal.
        /// </summary>
        public List<AuthenticationCode> GetAll()
        {
            try
            {
                return _authCode.ToList();
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }
            finally
            {
                _realm.Dispose();
            }
        }

        /// <summary>
        /// Retorna todas as intâncias da entidade principal usando um filtro (predicado).
        /// </summary>
        /// <param name="predicate">Predicado</param>
        public List<AuthenticationCode> GetAll(Expression<Func<AuthenticationCode, bool>> predicate)
        {
            try
            {
                return _authCode.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }
            finally
            {
                _realm.Dispose();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal buscando só pelo ID.
        /// </summary>
        public AuthenticationCode GetById(int pkId)
        {
            try
            {
                return _authCode.FirstOrDefault(x => x.Id == pkId);
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }
            finally
            {
                _realm.Dispose();
            }
        }

        /// <summary>
        /// Insere um novo registro na entidade principal.
        /// </summary>
        public bool Insert(AuthenticationCode entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _realm.CreateObject<AuthenticationCode>();
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
            finally
            {
                _realm.Dispose();
            }
        }

        /// <summary>
        /// Insere uma lista de novos registros na entidade principal.
        /// </summary>
        public bool Insert(List<AuthenticationCode> entities)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _realm.CreateObject<AuthenticationCode>();

                    foreach (var entity in entities)
                    {
                        obj = entity;
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
            finally
            {
                _realm.Dispose();
            }
        }

        /// <summary>
        /// Atualizar uma instância da entidade principal.
        /// </summary>
        public bool Update(AuthenticationCode entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _authCode.First(x => x.Id == entity.Id);
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
            finally
            {
                _realm.Dispose();
            }
        }
    }
}

