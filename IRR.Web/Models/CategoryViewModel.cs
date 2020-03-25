using System.Collections.Generic;
using IRR.Core;
using IRR.Core.DtoModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IRR.Web.Models
{
    public class CategoryViewModel
    {
        public CreateCategoryDto CategoryDto { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        public ICollection<Category> Children { get; set; } = new List<Category>();
        public SelectList CategorySelectList { get; set; }
    }
}
