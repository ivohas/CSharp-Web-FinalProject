using BookFindingAndRatingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookFindingAndRatingSystem.Data.Configurations
{
    public class PublisherEntityConfiguraion : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(this.GeneretePublishers());
        }

        public Publisher[] GeneretePublishers()
        {
            ICollection<Publisher> publishers = new HashSet<Publisher>();
             Publisher publisher;
            publisher = new Publisher { Id = 1, Name = "Penguin Random House" };
            publishers.Add(publisher);
            publisher =  new Publisher { Id = 2, Name = "HarperCollins" };
            publishers.Add(publisher);
            publisher = new Publisher { Id = 3, Name = "Simon & Schuster" };
            publishers.Add(publisher);
            publisher = new Publisher { Id = 4, Name = "Hachette Livre" };
            publishers.Add(publisher);
            publisher = new Publisher { Id = 5, Name = "Macmillan Publishers" };
            publishers.Add(publisher);
            publisher = new Publisher { Id = 6, Name = "Scholastic Corporation" };
            publishers.Add(publisher);
            publisher = new Publisher { Id = 7, Name = "Pearson Education" };
            publishers.Add(publisher);

            return publishers.ToArray();
        }
    }
}
