﻿using BookFindingAndRatingSystem.Data.Configurations;
using BookFindingAndRatingSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookFindingAndRatingSystem.Web.Data
{
    public class BooksDbContext : IdentityDbContext<AplicationUser,IdentityRole<Guid>,Guid>
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly= Assembly.GetAssembly(typeof(BooksDbContext)) ??
                Assembly.GetExecutingAssembly();

            builder.ApplyConfiguration(new BookEntityConfiguraion());
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new PublisherEntityConfiguraion());
            base.OnModelCreating(builder);
        }
    }
}