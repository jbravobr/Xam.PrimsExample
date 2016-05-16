using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Realms;

namespace IcatuzinhoApp
{
    public class LogExceptionRepository : BaseRepository, ILogExceptionRepository
    {
        private RealmResults<LogException> _logException
        {
            get
            {
                return _realm.All<LogException>();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public bool Any()
        {
            try
            {
                return _logException.Any();
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
        public bool Delete(LogException entity)
        {
            try
            {
                if (_logException.Any(x => x.Id == entity.Id))
                {
                    using (var tran = _realm.BeginWrite())
                    {
                        _realm.Remove(_logException.First(x => x.Id == entity.Id));
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
        public LogException Get()
        {
            try
            {
                return _logException.FirstOrDefault();
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
        public LogException Get(Expression<Func<LogException, bool>> predicate)
        {
            try
            {
                return _logException.FirstOrDefault(predicate);
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
        public List<LogException> GetAll()
        {
            try
            {
                return _logException.ToList();
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
        public List<LogException> GetAll(Expression<Func<LogException, bool>> predicate)
        {
            try
            {
                return _logException.Where(predicate).ToList();
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
        public LogException GetById(int pkId)
        {
            try
            {
                return _logException.FirstOrDefault(x=>x.Id == pkId);
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
        public bool Insert(LogException entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _realm.CreateObject<LogException>();
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
        public bool Insert(List<LogException> entities)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _realm.CreateObject<LogException>();

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
        public bool Update(LogException entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _logException.First(x => x.Id == entity.Id);
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

