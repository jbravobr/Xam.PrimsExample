using System;
using System.Threading.Tasks;
using SQLite.Net.Async;
using Xamarin.Forms;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IcatuzinhoApp
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        readonly SQLiteAsyncConnection conn;
        readonly AsyncLock Mutex = new AsyncLock();

        public BaseRepository()
        {
            this.conn = DependencyService.Get<ISQLite>().GetConnection();
            CreateDataBase().ConfigureAwait(false);
        }

        /// <summary>
        /// Criação da base
        /// </summary>
        private async Task CreateDataBase()
        {
            try
            {
                using (await Mutex.LockAsync().ConfigureAwait(false))
                {
                    await conn.CreateTableAsync<AuthenticationCode>();
                    await conn.CreateTableAsync<Driver>();
                    await conn.CreateTableAsync<LogException>();
                    await conn.CreateTableAsync<Schedule>();
                    await conn.CreateTableAsync<Station>();
                    await conn.CreateTableAsync<Transaction>();
                    await conn.CreateTableAsync<Travel>();
                    await conn.CreateTableAsync<User>();
                    await conn.CreateTableAsync<Vehicle>();
                    await conn.CreateTableAsync<Weather>();
                }
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
            }
        }

        /// <summary>
        /// Insere ou atualiza entidades existente e seus filhos.
        /// </summary>
        public async Task<bool> InsertOrReplaceWithChildrenAsync(T entity)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                try
                {
                    await this.conn.InsertOrReplaceWithChildrenAsync(entity, recursive: true);
                    return await Task.FromResult<bool>(true);
                }
                catch (Exception ex)
                {
                    new LogExceptionService().SubmitToInsights(ex);
                    return await Task.FromResult<bool>(false);
                }
            }
        }

        /// <summary>
        /// Insere uma nova coleção da entidade T no Banco de Dados.
        /// </summary>
        public async Task<bool> InsertOrReplaceAllWithChildrenAsync(IList<T> list)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {

                try
                {
                    await this.conn.InsertOrReplaceAllWithChildrenAsync(list, recursive: true);
                    return await Task.FromResult<bool>(true);
                }
                catch (Exception ex)
                {
                    new LogExceptionService().SubmitToInsights(ex);
                    return await Task.FromResult<bool>(false);
                }
            }
        }

        /// <summary>
        /// Delete uma determinada entidade T do Banco de Dados
        /// </summary>
        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                using (await Mutex.LockAsync().ConfigureAwait(false))
                {
                    await this.conn.DeleteAsync(entity, recursive: false);
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return await Task.FromResult(false);

            }
        }

        /// <summary>
        /// Retorna uma coleção de Entidades T de acordo com um predicado
        /// </summary>
        public async Task<List<T>> GetAllWithChildrenAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                using (await Mutex.LockAsync().ConfigureAwait(false))
                {
                    return await this.conn.GetAllWithChildrenAsync<T>(predicate, recursive: true);
                }
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return null;
            }
        }

        public async Task<T> GetWithChildrenAsync(Expression<Func<T, bool>> expr)
        {
            try
            {
                return await this.conn.GetWithChildrenAsync<T>(expr);

            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return null;
            }
        }

        public async Task<T> GetAllAsync()
        {
            try
            {
                return await this.conn.Table<T>().FirstOrDefaultAsync();

            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return null;
            }
        }

        /// <summary>
        /// Retorna um único registro da entidade T
        /// </summary>
        /// <param name = "pkId">Chave primária para busca</param>
        public async Task<T> GetWithChildrenByIdAsync(int pkId)
        {
            try
            {
                return await this.conn.GetWithChildrenAsync<T>(pkId, recursive: true);
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return null;
            }
        }

        /// <summary>
        /// Retorna todas as Entidades T
        /// </summary>
        public async Task<List<T>> GetAllWithChildrenAsync()
        {
            try
            {
                using (await Mutex.LockAsync().ConfigureAwait(false))
                {
                    return await this.conn.GetAllWithChildrenAsync<T>(null, recursive: true);
                }
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return null;
            }
        }

        /// <summary>
        /// Atualizar uma Entidade T
        /// </summary>
        public async Task<bool> UpdateWithChildrenAsync(T entity)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {

                try
                {
                    await this.conn.UpdateWithChildrenAsync(entity);
                    return await Task.FromResult<bool>(true);
                }
                catch (Exception ex)
                {
                    new LogExceptionService().SubmitToInsights(ex);
                    return await Task.FromResult<bool>(false);
                }
            }
        }

        /// <summary>
        /// Verificar se existe registro
        /// </summary>
        public async Task<bool> Any()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {

                try
                {
                    return await this.conn.Table<T>().CountAsync() > 0;
                }
                catch (Exception ex)
                {
                    new LogExceptionService().SubmitToInsights(ex);
                    return await Task.FromResult(false);
                }
            }
        }
    }
}

