using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ExampleRepository : GenericRepository<Example>, IExampleRepository
    {
        public ExampleRepository(DbContext context) : base(context) { }
    }
}
