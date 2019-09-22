using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CoreExample.Models.Entities;

namespace CoreExample.Repository
{
    public class CoreExampleDbContext : DbContext
    {
        public CoreExampleDbContext(DbContextOptions<CoreExampleDbContext> options)
            : base(options)
        { }

        public DbSet<ValueEntity> ValueEntities { get; set; }
    }
}