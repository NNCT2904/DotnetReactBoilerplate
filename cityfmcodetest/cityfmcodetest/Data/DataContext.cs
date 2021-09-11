using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cityfmcodetest.Models;
using Microsoft.EntityFrameworkCore;

namespace cityfmcodetest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
