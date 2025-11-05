using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Resolves repositories for entities using dependency injection.
    /// </summary>
    /// <remarks>
    /// This class enforces that every entity type must have a registered repository in the DI container.
    /// It throws an exception if a repository is not found, helping catch configuration errors early.
    /// </remarks>
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider serviceProvider;
        private readonly DbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">The DI service provider.</param>
        /// <param name="dbContext">The database context.</param>
        public RepositoryFactory(IServiceProvider serviceProvider, DbContext dbContext)
        {
            this.serviceProvider = serviceProvider;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Creates a repository for the specified entity type using DI.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>An instance of <see cref="IGenericRepository{TEntity}"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if no repository is registered for the entity type.
        /// </exception>
        /// <remarks>
        /// Ensures that all repositories are registered in the DI container, promoting consistency and reliability.
        /// </remarks>
        public IGenericRepository<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            IGenericRepository<TEntity>? repository =
                serviceProvider.GetService<IGenericRepository<TEntity>>();

            if (repository is null)
            {
                throw new InvalidOperationException(
                    $"No specific repository registered for entity type {typeof(TEntity).Name}. " +
                    "Ensure IRepository<TEntity> is registered in Program.cs."
                );
            }

            return repository;
        }
    }
}