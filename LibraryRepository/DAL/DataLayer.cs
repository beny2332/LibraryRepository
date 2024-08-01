using Microsoft.EntityFrameworkCore;
using LibraryRepository.Models;

namespace LibraryRepository.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string ConnectionString) : base(GetOptions(ConnectionString))
        {
            Database.EnsureCreated();
            Seed();
        }

        private void Seed()
        {
            Library library = AddDefaultLibrary();
            SaveChanges();
        }

        private Library AddDefaultLibrary()
        {
            Library library;
            if (!Libraries.Any())
            {
                library = new Library {Genre = "Tanch/Bible" };
                Libraries.Add(library);
            }
            else
            {
                library = Libraries.First();
            }
            return library;
        }


        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options;
        }


        public DbSet<Library> Libraries { get; set; }

        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
