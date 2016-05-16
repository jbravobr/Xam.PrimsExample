using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Realms;

namespace IcatuzinhoApp
{
    public class StationRepository : BaseRepository, IStationRepository
    {
        private RealmResults<Station> _station
        {
            get
            {
                return _realm.All<Station>();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public bool Any()
        {
            try
            {
                return _station.Any();
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
        public bool Delete(Station entity)
        {
            try
            {
                if (_station.Any(x => x.Id == entity.Id))
                {
                    using (var tran = _realm.BeginWrite())
                    {
                        _realm.Remove(_station.First(x => x.Id == entity.Id));
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
        public Station Get()
        {
            try
            {
                return _station.FirstOrDefault();
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
        public Station Get(Expression<Func<Station, bool>> predicate)
        {
            try
            {
                return _station.FirstOrDefault(predicate);
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
        public List<Station> GetAll()
        {
            try
            {
                return _station.ToList();
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
        public List<Station> GetAll(Expression<Func<Station, bool>> predicate)
        {
            try
            {
                return _station.Where(predicate).ToList();
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
        public Station GetById(int pkId)
        {
            try
            {
                return _station.FirstOrDefault(x=>x.Id == pkId);
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
        public bool Insert(Station entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _realm.CreateObject<Station>();
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
        public bool Insert(List<Station> entities)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _realm.CreateObject<Station>();

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
        public bool Update(Station entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _station.First(x => x.Id == entity.Id);
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

