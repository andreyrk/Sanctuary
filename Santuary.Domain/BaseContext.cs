using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sanctuary.Domain.Entities;
using System;

#nullable disable

namespace Sanctuary.Domain
{
    public partial class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Animal> Species { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
