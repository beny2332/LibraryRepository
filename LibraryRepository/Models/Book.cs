using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryRepository.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Shelf? shelf { get; set; }
        [NotMapped]
        public int? LibId { get; set; }
        public List<Shelf> ? shelvesList { get; set; }

        public Library? library { get; set; }
    }
}
