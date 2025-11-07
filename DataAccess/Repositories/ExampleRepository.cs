using DataAccess.RepositoryInterfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ExampleRepository : GenericRepository<Example>, IExampleRepository
    {
        public ExampleRepository(DbContext context) : base(context) { }
    }
}
