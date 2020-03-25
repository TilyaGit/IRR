using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IRR.Core;
using IRR.Web.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IRR.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public CategoryController(ICategoryRepository categoryRepository,
            [NotNull] IUnitOfWorkFactory unitOfWorkFactory)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetRootCategories();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            var categories = _categoryRepository.GetCategories();
            var viewModel = new CategoryViewModel()
            {
                CategorySelectList = new SelectList(categories, "Id", "Name")
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}