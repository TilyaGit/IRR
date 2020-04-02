using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRR.Core;
using IRR.DataAccess;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace IRR.Web.Controllers
{
    public class CategoryFieldController : Controller
    {
        private readonly CategoryFieldRepository _fieldRepository;
        private readonly CategoryItemRepository _itemRepository;
        public CategoryFieldController([NotNull] CategoryFieldRepository fieldRepository,
                                       [NotNull] CategoryItemRepository itemRepository)
        {
            _fieldRepository = fieldRepository ?? throw new ArgumentNullException(nameof(fieldRepository));
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }
        public async Task<IActionResult> Index(int id)
        {
            var categoryItem = await _itemRepository.Get(id);
            ViewBag.CategoryItemId = id;

            return View(categoryItem);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var categoryItem = await _itemRepository.Get(id);

            ViewBag.CategoryItemId = id;
            if (categoryItem != null) ViewBag.CategoryItemName = categoryItem.Name;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryField categoryField)
        {
            await _fieldRepository.AddCategoryField(categoryField);
            return RedirectToAction(nameof(Index), new { id = categoryField.Id});
        }
    }
}