using System;
using System.Collections.Generic;
using System.Text;

namespace IRR.Core.DtoModels
{
    public class CreateCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        public ICollection<Category> Children { get; set; } = new List<Category>();
    }
}
