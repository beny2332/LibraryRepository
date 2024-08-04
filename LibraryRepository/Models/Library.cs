using System.ComponentModel.DataAnnotations;

namespace LibraryRepository.Models
{
    public class Library
    {
        public Library() 
        {
            ShelfList = new List<Shelf>();
        }
        [Key]
        public int Id { get; set; }

        [Display(Name ="Library Genre")]
        public string Genre { get; set; } = string.Empty;
        
        [Display(Name ="Shelves")]
        public List<Shelf> ShelfList { get; set; }
        public void AddShelf(int width, int height) 
        {
            Shelf newShelf = new Shelf {Width = width, Height=height};
            ShelfList.Add(newShelf);
        }
        
    }
}
