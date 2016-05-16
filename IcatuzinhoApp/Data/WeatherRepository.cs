using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Realms;

namespace IcatuzinhoApp
{
    public class WeatherRepository : BaseRepository, IWeatherRepository
    {
        private RealmResults<Weather> _weather
        {
            get
            {
                return _realm.All<Weather>();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public bool Any()
        {
            try
            {
                return _weather.Any();
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
        public bool Delete(Weather entity)
        {
            try
            {
                if (_weather.Any(x => x.Id == entity.Id))
                {
                    using (var tran = _realm.BeginWrite())
                    {
                        _realm.Remove(_weather.First(x => x.Id == entity.Id));
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
        public Weather Get()
        {
            try
            {
                return _weather.FirstOrDefault();
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
        public Weather Get(Expression<Func<Weather, bool>> predicate)
        {
            try
            {
                return _weather.FirstOrDefault(predicate);
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
        public List<Weather> GetAll()
        {
            try
            {
                return _weather.ToList();
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
        public List<Weather> GetAll(Expression<Func<Weather, bool>> predicate)
        {
            try
            {
                return _weather.Where(predicate).ToList();
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
        public Weather GetById(int pkId)
        {
            try
            {
                return _weather.FirstOrDefault(x => x.Id == pkId);
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
        public bool Insert(Weather entity)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<Weather>();
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
        public bool Insert(List<Weather> entities)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<Weather>();

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
        public bool Update(Weather entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _weather.First(x => x.Id == entity.Id);
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

