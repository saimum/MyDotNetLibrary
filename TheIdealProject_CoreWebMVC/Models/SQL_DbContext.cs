using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheIdealProject_CoreWebMVC.Models
{
    public class SQL_DbContext: DbContext
    {
        public SQL_DbContext(DbContextOptions<SQL_DbContext>options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Division> Division { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Thana> Thana { get; set; }
    }
}
