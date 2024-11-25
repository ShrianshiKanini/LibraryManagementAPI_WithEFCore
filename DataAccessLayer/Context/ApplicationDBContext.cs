using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<RequestedBooks> RequestedBooks { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .HasOne(book => book.Authors)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId);

            modelBuilder.Entity<Books>()
                .HasOne(book => book.Genres)
                .WithMany(genre => genre.Books)
                .HasForeignKey(book => book.GenreId);
        }

    }
}
