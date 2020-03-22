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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var category = new Category
                {
                    Name = "Офисная техника",
                    ParentId = 1
                };

                await _categoryRepository.Add(category);

                uow.Commit();
                return View();
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> CreatePost()
        //{
        //    return View();
        //}
    }
}