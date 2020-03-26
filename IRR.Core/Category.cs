using System.Collections.Generic;

namespace IRR.Core
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        public ICollection<Category> Children { get; set; } = new List<Category>();

       // CategoryModelFieldType stringType = CategoryModelFieldType.String;

    }

    public class CategoryModelFieldType
    {
        public static CategoryModelFieldType String = new CategoryModelFieldType(1,"Строка");
        public static CategoryModelFieldType Int = new CategoryModelFieldType(2,"int");
        public static CategoryModelFieldType Bool = new CategoryModelFieldType(3,"bool");

        public static IEnumerable<CategoryModelFieldType> GetTypes => new[] {Int, String,Bool};
        public CategoryModelFieldType(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public string Name { get;  }
        public int Value { get; }
    }
}
