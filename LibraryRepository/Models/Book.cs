using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryRepository.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Width { get; set; }
        public int Height { get; set; }
        public Shelf? Shelf { get; set; }
        
    }
}
