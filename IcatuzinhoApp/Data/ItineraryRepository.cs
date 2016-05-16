using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Realms;

namespace IcatuzinhoApp
{
    public class ItineraryRepository : BaseRepository, IItineraryRepository
    {
        private RealmResults<Itinerary> _itinerary
        {
            get
            {
                return _realm.All<Itinerary>();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public bool Any()
        {
            try
            {
                return _itinerary.Any();
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
        public bool Delete(Itinerary entity)
        {
            try
            {
                if (_itinerary.Any(x => x.Id == entity.Id))
                {
                    using (var tran = _realm.BeginWrite())
                    {
                        _realm.Remove(_itinerary.First(x => x.Id == entity.Id));
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
        public Itinerary Get()
        {
            try
            {
                return _itinerary.FirstOrDefault();
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
        public Itinerary Get(Expression<Func<Itinerary, bool>> predicate)
        {
            try
            {
                return _itinerary.FirstOrDefault(predicate);
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
        public List<Itinerary> GetAll()
        {
            try
            {
                return _itinerary.ToList();
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
        public List<Itinerary> GetAll(Expression<Func<Itinerary, bool>> predicate)
        {
            try
            {
                return _itinerary.Where(predicate).ToList();
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
        public Itinerary GetById(int pkId)
        {
            try
            {
                return _itinerary.FirstOrDefault(x => x.Id == pkId);
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
        public bool Insert(Itinerary entity)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<Itinerary>();
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
        public bool Insert(List<Itinerary> entities)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<Itinerary>();

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
        public bool Update(Itinerary entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _itinerary.First(x => x.Id == entity.Id);
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

