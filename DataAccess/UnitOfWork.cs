using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Implements the Unit of Work pattern to coordinate repository operations and commit changes as a single transaction.
    /// </summary>
    /// <remarks>
    /// This class encapsulates the DbContext and provides access to repositories via a factory.
    /// It ensures that all changes are saved together, promoting consistency and atomicity.
    /// </remarks>
    public class UnitOfWork
    {
        private readonly DbContext dbContext;
        private readonly IRepositoryFactory repositoryFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context to use for operations.</param>
        /// <param name="repositoryFactory">The factory for creating repositories.</param>
        public UnitOfWork(DbContext dbContext, IRepositoryFactory repositoryFactory)
        {
            this.dbContext = dbContext;
            this.repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Commits all changes made in the context to the database.
        /// </summary>
        public void Save() => dbContext.SaveChanges();

        /// <summary>
        /// Gets a repository for the specified entity type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>An instance of <see cref="IGenericRepository{TEntity}"/> for the entity.</returns>
        /// <remarks>
        /// This method delegates repository creation to the factory, ensuring proper DI configuration.
        /// </remarks>
        public IGenericRepository GetRepository<TEntity>() where TEntity : class
        {
            return repositoryFactory.CreateRepository<TEntity>();
        }
    }
}
