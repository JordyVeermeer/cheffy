﻿using cheffy_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace cheffy_dotnet.Repositories
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .Property(r => r.Name)
                .IsRequired();
        }

        public DbSet<Recipe> Recipes { get; set; } = null!;
    }
}
