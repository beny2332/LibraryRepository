using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryRepository.Models
{
    public class Shelf
    {
        public Shelf()
        {
            BookList = new List<Book>();
        }
        [Key]
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }      
        public Library Library { get; set; }
        public List<Book> BookList { get; set; }
    }
}
