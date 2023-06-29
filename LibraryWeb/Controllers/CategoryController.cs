using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;

        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The displayOrder cannot exactly match the Name.");
            }

            if(ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");

            }

            return View();
            
            
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromdb = _categoryRepo.Get(u=>u.Id==id);
            if(categoryfromdb==null) { return NotFound(); }


            return View(categoryfromdb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
           

            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromdb = _categoryRepo.Get(u=>u.Id==id);
            if (categoryfromdb == null) { return NotFound(); }


            return View(categoryfromdb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Category? obj = _categoryRepo.Get(u => u.Id == id);
            if (obj==null) { return NotFound() ; }

            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");   

           


        }
    }
}
