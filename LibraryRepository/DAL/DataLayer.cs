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
            if (!Libraries.Any())
            {
                Library library = new Library { Genre = "fantazy"};
                library.ShelfList = CreateDefultShelfList(library);
                Libraries.Add(library);
                SaveChanges();
            }
        }
        private List<Shelf> CreateDefultShelfList(Library library) 
        {
            List<Shelf> shelfList = new List<Shelf>();

            Shelf shelf = new Shelf { Height = 50, Width = 100, Library = library};

            shelf.BookList = CreateDefultBookList(shelf);

            shelfList.Add(shelf);
            Shelves.Add(shelf);
            return shelfList;
        }
        private List<Book> CreateDefultBookList(Shelf shelf) 
        {
            List<Book> bookList = new List<Book>();

            Book book = new Book { Height = 10, Width = 4, Title = "Harry Potter", Shelf = shelf};

            bookList.Add(book);
            Books.Add(book);

            return bookList;
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
