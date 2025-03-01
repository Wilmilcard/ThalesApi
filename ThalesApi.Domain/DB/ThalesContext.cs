using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ThalesApi.Domain.Models;
using ThalesApi.Domain.Seed;
using static System.Collections.Specialized.BitVector32;

namespace ThalesApi.Domain.DB
{
    public class ThalesContext : DbContext
    {
        public ThalesContext(DbContextOptions<ThalesContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<User> usuarios { get; set; }
        public DbSet<Sesion> sesiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings
                    .Log(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
