using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            List<Product> productObjList = _unitOfWork.Product.GetAll().ToList();
            return View(productObjList);
        }
        public IActionResult Create()
        {
            ProductVM pVMObj = new()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
            };
            return View(pVMObj);
        }

        [HttpPost]
        public IActionResult Create(ProductVM obj)
        {
            if (obj.Product.Title.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (obj.Product.Title == obj.Product.Description.ToString())
            {
                ModelState.AddModelError("name", "The name and the display order can't be the same");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            } else
            {
                obj.CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(obj);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Product? productObj = _categoryRepo.Categories.Find(id);
            //Product? productObj1 = _categoryRepo.Categories.FirstOrDefault(obj => obj.Id == id);
            //Product? productObj2 = _categoryRepo.Categories.Where(obj => obj.Id == id).FirstOrDefault();
            Product? productObj = _unitOfWork.Product.Get(u => u.Id == id);
            if (productObj == null)
            {
                return NotFound();
            }

            return View(productObj);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (obj.Title.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (obj.Title == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The name and the display order can't be the same");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product edited successfully";
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

            Product? productObj = _unitOfWork.Product.Get(u => u.Id == id);

            if (productObj == null)
            {
                return NotFound();
            }

            return View(productObj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? productObj = _unitOfWork.Product.Get(obj => obj.Id == id);

            if (productObj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(productObj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
