using System;
using System.Threading.Tasks;
using IRR.Core;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace IRR.Web.Controllers
{
    public class CategoryItemController : Controller
    {
        private readonly ICategoryItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryItemController([NotNull] ICategoryItemRepository itemRepository,
            [NotNull] ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<IActionResult> Index(int id)
        {
            var category = await _categoryRepository.Get(id);
            ViewBag.CategoryId = id;

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var category = await _categoryRepository.Get(id);

            ViewBag.CategoryItemId = id;
            if (category != null) ViewBag.CategoryItemName = category.Name;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryItem categoryItem)
        {
            await _itemRepository.AddCategoryItem(categoryItem);
            return RedirectToAction(nameof(Index), new {id = categoryItem.CategoryId });
        }
    }
}