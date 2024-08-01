using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryRepository.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        [NotMapped]
        public int? LibId { get; set; }
        public Library? library { get; set; }
    }
}
