using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Entitles.EntityMapper;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DependenciaMap());
            modelBuilder.ApplyConfiguration(new EmpleadoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}