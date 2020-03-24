using System.Collections.Generic;
using System.Text;
using IRR.Core;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IRR.Web
{
    public static class CategoryHelper
    {
        public static HtmlString ShowCategories(this IHtmlHelper html, ICollection<Category> categories)
        {
            var builder = new StringBuilder();
            builder = RecursiveCategories(builder, categories);
            return new HtmlString(builder.ToString());
        }

        public static StringBuilder RecursiveCategories(StringBuilder builder, ICollection<Category> categories)
        {
            if (categories.Count == 0)
            {
                return builder;
            }
            builder.Append("<ul>");
            foreach (var category in categories)
            {
                builder.Append("<li>");
                builder.Append(category.Name);
                RecursiveCategories(builder, category.Children);
                builder.Append("</li>");
            }
            return builder.Append("</ul>");
        }
    }
}