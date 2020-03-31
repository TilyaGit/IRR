using System;
using IRR.Core;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace IRR.Web.Controllers
{
    public class CategoryFieldController : Controller
    {
        private readonly ICategoryFieldRepository _fieldRepository;

        public CategoryFieldController([NotNull] ICategoryFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository ?? throw new ArgumentNullException(nameof(fieldRepository));
        }
        public ActionResult  Index(int id)
        {
            if (id != null)
            {
                _fieldRepository.GetFields(id);
                //ViewBag.CategoryParentName = categoryModelField.Name;
                //ViewBag.CategoryParenId = categoryModelField.Id;
            }
            return View();
        }

    }
}