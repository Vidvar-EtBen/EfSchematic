using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Factory interface for creating generic repositories for entities.
    /// </summary>
    /// <remarks>
    /// This abstraction allows for decoupling repository creation from concrete implementations and supports dependency injection.
    /// </remarks>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Creates a generic repository for the specified entity type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>An instance of <see cref="IGenericRepository{TEntity}"/> for the entity.</returns>
        IGenericRepository<TEntity> CreateRepository<TEntity>() where TEntity : class;
    }
}
