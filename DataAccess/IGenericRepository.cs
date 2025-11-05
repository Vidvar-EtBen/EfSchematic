using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Marker interface for generic repositories.
    /// </summary>
    /// <remarks>
    /// Used for type safety and to allow non-generic handling of repositories.
    /// </remarks>
    public interface IGenericRepository { }

    /// <summary>
    /// Defines basic CRUD operations for a repository of a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <remarks>
    /// This interface should be implemented by all repositories to ensure consistent data access patterns.
    /// </remarks>
    public interface IGenericRepository<TEntity> : IGenericRepository where TEntity : class
    {
        /// <summary>
        /// Retrieves all entities from the data store.
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Updates the specified entity in the data store.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity from the data store.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        void DeleteById(int id);
    }
}
