using LibraryRepository.DAL;
using LibraryRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryRepository.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            List<Library> libraries = Data.Get.Libraries.Include(lib => lib.ShelvesList).ToList();
            return View(libraries);
        }
        public IActionResult Create() 
        {
            return View(new Library());
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Library library)
        { 
            Data.Get.Libraries.Add(library);
            Data.Get.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CreateBook(int id)
        {
            Library? library = Data.Get.Libraries.Find(id);
            if (library == null)
            {
                return NotFound();
            }
            ViewBag.id = id;

            return View(new Book());
        }
        public IActionResult AddShelf(int id) 
        {
            Library? library = Data.Get.Libraries.Find(id);
            if (library == null)
            {
                return NotFound();
            }
            ViewBag.id = id;
            
            return View(new Shelf());
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelf(Shelf newShelf)
        {
            Library library = Data.Get.Libraries.FirstOrDefault(l => l.Id == newShelf.LibId);
            if (ModelState.IsValid)
            {
                newShelf.Id = 0;
                newShelf.library = library;
                Data.Get.Shelves.Add(newShelf);
                Data.Get.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //[HttpPost, ValidateAntiForgeryToken]
        //public IActionResult AddShelf(Library libraryFromRequst, Shelf newShelf) 
        //{
        //    Library? libraryFromDb = Data.Get.Libraries.Find(libraryFromRequst);
        //    return RedirectToAction("Index");
        //}
        //public IActionResult AddShelf(int? id) 
        //{
        //    if (id == null) 
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    Library? library = Data.Get.Libraries.Include(s=> s.ShelvesList).FirstOrDefault(library=> library.Id == id);
        //    if (library == null) 
        //    {
        //        return RedirectToAction("Index");

        //    }
        //    return View(library);
        //}
    }
}

        //public IActionResult AddShelf(int id)
        //{
        //    var library = Data.Get.Libraries.Find(id);
        //    if (library == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = new ShelfViewModel { LibraryId = id };
        //    return View(model);
        //}