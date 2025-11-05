using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Repository implementation for <see cref="Example"/> entities.
    /// Inherits generic CRUD operations from <see cref="GenericRepository{Example}"/>.
    /// </summary>
    public class ExampleRepository : GenericRepository<Example>, IExampleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleRepository"/> class.
        /// </summary>
        /// <param name="context">The database context used for data access.</param>
        public ExampleRepository(DbContext context) : base(context) { }
    }
}
