using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Context
{
    public class ExampleContext : DbContext
    {
        // Delete this file
        public virtual DbSet<Example> Examples { get; set; }
    }
}
