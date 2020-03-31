using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IRR.Core;
using JetBrains.Annotations;

namespace IRR.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController([NotNull]ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetRootCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id != null)
            {
                var parentCategory = _categoryRepository.GetCategory(id);
                ViewBag.CategoryParentName = parentCategory.Name;
                ViewBag.CategoryParenId = parentCategory.Id;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}