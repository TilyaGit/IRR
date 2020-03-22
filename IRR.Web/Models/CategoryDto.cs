using Microsoft.AspNetCore.Mvc.Rendering;

namespace IRR.Web.Models
{
    public class CategoryDto
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}
