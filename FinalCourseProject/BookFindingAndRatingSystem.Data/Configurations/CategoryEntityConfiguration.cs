using BookFindingAndRatingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BookFindingAndRatingSystem.Data.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenereteCategories());
        }
        private Category[] GenereteCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();
            Category category;
            category = new Category() { Id = 1, Name = "Horror" };
            categories.Add(category);
            category = new Category() { Id = 2, Name = "Romance" };
            categories.Add(category);
            category = new Category() { Id = 3, Name = "Science Fiction" };
            categories.Add(category);
            category = new Category() { Id = 4, Name = "Mystery" };
            categories.Add(category);
            category = new Category() { Id = 5, Name = "Fantasy" };
            categories.Add(category);
            category = new Category() { Id = 6, Name = "Thriller" };
            categories.Add(category);
            category = new Category() { Id = 7, Name = "Comedy" };
            categories.Add(category);
            category = new Category() { Id = 8, Name = "Fiction" };
            categories.Add(category);
            return categories.ToArray();
        }
    }
}
