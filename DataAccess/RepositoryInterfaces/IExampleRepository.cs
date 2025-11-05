using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Repository interface for <see cref="Example"/> entities.
    /// Inherits basic CRUD operations from <see cref="IGenericRepository{Example}"/>.
    /// </summary>
    public interface IExampleRepository : IGenericRepository<Example> 
    { 
        // Add custom methods for Example-specific queries here if needed.
    }
}
