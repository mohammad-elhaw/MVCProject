using Microsoft.EntityFrameworkCore;
using Project.DAL.Data.Configurations;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Data
{
    public class AppDbContext : DbContext
    {
        // we make initialize to DbContextOptions because it execute DbContext.OnConfiguring
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }

        public DbSet<Department> Departments { get; set; }
    }
}
