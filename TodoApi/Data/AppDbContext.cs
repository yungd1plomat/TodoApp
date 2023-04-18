using Microsoft.EntityFrameworkCore;
using System;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoList> Lists { get; set; }

        public DbSet<TodoItem> Items { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>()
                .HasMany(l => l.Items)
                .WithOne(i => i.List)
                .HasForeignKey(i => i.ListId);
        }
    }
}
