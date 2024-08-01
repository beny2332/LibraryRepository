using System.ComponentModel.DataAnnotations;

namespace LibraryRepository.Models
{
    public class Library
    {
        public Library() 
        {
            ShelvesList = new List<Shelf>();
        }
        [Key]
        public int Id { get; set; }

        [Display(Name ="Library Genre")]
        public string Genre { get; set; }
        [Display(Name ="Shelves")]
        public List<Shelf> ShelvesList { get; set; }
        public void AddShelf(int width, int height) 
        {
            Shelf newShelf = new Shelf {Width = width, Height=height};
            ShelvesList.Add(newShelf);
        }
        
    }
}
