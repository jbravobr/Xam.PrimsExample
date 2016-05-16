using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Realms;

namespace IcatuzinhoApp
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        private RealmResults<Transaction> _transaction
        {
            get
            {
                return _realm.All<Transaction>();
            }
        }

        /// <summary>
        /// Retorna uma instância da entidade principal.
        /// </summary>
        public bool Any()
        {
            try
            {
                return _transaction.Any();
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
        public bool Delete(Transaction entity)
        {
            try
            {
                if (_transaction.Any(x => x.Id == entity.Id))
                {
                    using (var tran = _realm.BeginWrite())
                    {
                        _realm.Remove(_transaction.First(x => x.Id == entity.Id));
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
        public Transaction Get()
        {
            try
            {
                return _transaction.FirstOrDefault();
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
        public Transaction Get(Expression<Func<Transaction, bool>> predicate)
        {
            try
            {
                return _transaction.FirstOrDefault(predicate);
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
        public List<Transaction> GetAll()
        {
            try
            {
                return _transaction.ToList();
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
        public List<Transaction> GetAll(Expression<Func<Transaction, bool>> predicate)
        {
            try
            {
                return _transaction.Where(predicate).ToList();
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
        public Transaction GetById(int pkId)
        {
            try
            {
                return _transaction.FirstOrDefault(x => x.Id == pkId);
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
        public bool Insert(Transaction entity)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<Transaction>();
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
        public bool Insert(List<Transaction> entities)
        {
            using (var tran = _realm.BeginWrite())
            {
                try
                {
                    var obj = _realm.CreateObject<Transaction>();

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
        public bool Update(Transaction entity)
        {
            try
            {
                using (var tran = _realm.BeginWrite())
                {
                    var obj = _transaction.First(x => x.Id == entity.Id);
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

