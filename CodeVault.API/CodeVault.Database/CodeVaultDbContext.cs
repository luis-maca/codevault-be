using CodeVault.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVault.Database
{
    public class CodeVaultDbContext : DbContext
    {
        public CodeVaultDbContext(DbContextOptions<CodeVaultDbContext> options)
            : base(options)
        {
        }
        // DbSet properties for your entities go here, e.g.:
         public DbSet<Snippet> Snippets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Snippet>().HasKey(s => s.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
