using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Realms;

namespace IcatuzinhoApp
{
    public class DriverRepository : BaseRepository, IDriverRepository
    {
        private RealmResults<Driver> _driver
        {
            get
            {
                return _realm.All<Driver>();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public bool Any()
        {
            try
            {
                return _driver.Any();
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
        public bool Delete(Driver entity)
        {
            try
            {
                if (_driver.Any(x => x.Id == entity.Id))
                {
                    using (var tran = _realm.BeginWrite())
                    {
                        _realm.Remove(_driver.First(x => x.Id == entity.Id));
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
        public Driver Get()
        {
            try
            {
                return _driver.FirstOrDefault();
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
        public Driver Get(Expression<Func<Driver, bool>> predicate)
        {
            try
            {
                return _driver.FirstOrDefault(predicate);
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
        public List<Driver> GetAll()
        {
            try
            {
                return _driver.ToList();
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
        public List<Driver> GetAll(Expression<Func<Driver, bool>> predicate)
        {
            try
            {
                return _driver.Where(predicate).ToList();
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
        public Driver GetById(int pkId)
        {
            try
            {
                return _driver.FirstOrDefault(x=>x.Id == pkId);
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
        public bool Insert(Driver entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _realm.CreateObject<Driver>();
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
        public bool Insert(List<Driver> entities)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _realm.CreateObject<Driver>();

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
        public bool Update(Driver entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _driver.First(x => x.Id == entity.Id);
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

