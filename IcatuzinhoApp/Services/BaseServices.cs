using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IcatuzinhoApp
{
    public class BaseServices<T> : IBaseServices<T> where T : class, new()
    {
        private BaseRepository<T> repository;

        #region IBaseServices implementation

        /// <summary>
        /// Insere os novos registros quando estes são lista.
        /// </summary>
        /// <returns>The or replace all with children async.</returns>
        /// <param name="list">List.</param>
        public async Task<bool> InsertOrReplaceAllWithChildrenAsync(List<T> list)
        {
            InitiateRepository();
            return await this.repository.InsertOrReplaceAllWithChildrenAsync(list);
        }

        /// <summary>
        /// Deleta o registro informado baseado na entidade.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="entidade">Entidade.</param>
        public async Task<bool> DeleteAsync(T entidade)
        {
            InitiateRepository();
            return await this.repository.DeleteAsync(entidade);
        }

        /// <summary>
        /// Retorna os dados da entidade e todos os relacionados base numa expressão filtro.
        /// </summary>
        /// <returns>The all with children async.</returns>
        /// <param name="predicate">Predicate.</param>
        public async Task<List<T>> GetAllWithChildrenAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null && predicate.Parameters.Count > 0)
                return await this.repository.GetAllWithChildrenAsync(predicate);

            return null;
        }

        /// <summary>
        /// Retorna todos os registros em lista do predicado informado.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="predicate">Predicate.</param>
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null && predicate.Parameters.Count > 0)
                return await this.repository.GetAsync(predicate);

            return null;
        }

        /// <summary>
        /// Retorna todos os registros e seus filhos, sem filtro.
        /// </summary>
        /// <returns>The all with children async.</returns>
        public async Task<List<T>> GetAllWithChildrenAsync()
        {
            return await this.repository.GetAllWithChildrenAsync();
        }

        /// <summary>
        /// Retornar uma  entidade com filtro em seu ID.
        /// </summary>
        /// <returns>The with children by identifier async.</returns>
        /// <param name="pkId">Pk identifier.</param>
        public async Task<T> GetWithChildrenByIdAsync(int pkId)
        {
            if (pkId > 0)
                return await this.repository.GetWithChildrenByIdAsync(pkId);

            return null;
        }

        /// <summary>
        /// Efetua a atualiação de uma entidade.
        /// </summary>
        /// <returns>The with children async.</returns>
        /// <param name="entity">Entity.</param>
        public async Task<bool> UpdateWithChildrenAsync(T entity)
        {
            return await this.repository.UpdateWithChildrenAsync(entity);
        }

        /// <summary>
        /// Verifica se existe a entidade informada
        /// </summary>
        public async Task<bool> Any()
        {
            return await this.repository.Any();
        }

        public Task<bool> InsertOrReplaceWithChildrenAsync(T entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Cria uma instância do repositório caso não exista uma já
        /// </summary>
        private void InitiateRepository()
        {
            if (this.repository == null)
                this.repository = new BaseRepository<T>();
        }
    }
}

