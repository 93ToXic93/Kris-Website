using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kris.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Kris.Infrastructure.Data
{
    public class KrisDbContext : DbContext
    {
        public KrisDbContext(DbContextOptions<KrisDbContext> options)
            : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
