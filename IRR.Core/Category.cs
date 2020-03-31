using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace IRR.Core
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        public ICollection<Category> Children { get; set; } = new List<Category>();
    }
    
    public class CategoryFieldType
    {
        public static CategoryFieldType String = new CategoryFieldType(1, "Строковой тип");
        public static CategoryFieldType Int = new CategoryFieldType(2, "Числовой тип");
        public static CategoryFieldType Bool = new CategoryFieldType(3, "Логический тип");
        public static CategoryFieldType Float = new CategoryFieldType(4, "Тип с плавающей точкой");
        public static IEnumerable<CategoryFieldType> GetTypes => new[] {Int, String,Bool};
        public CategoryFieldType(int value, string name)
        {
            Value = value;
            Name = name;
        }
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class CategoryField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryFieldType Type { get; set; }
    }
     
    public class CategoryItem : Category
    {
        public List<CategoryField> Fields { get; set; }
    }

    public class CatalogObject
    {   
        public int Id { get; set; }
    
        public CategoryItem CategoryItem { get; set; }

        public IDictionary<string, object> Values { get; set; } 

        public CatalogObject(CategoryItem category)
        {
            CategoryItem = category;
        }

        [NotNull]
        public object this[string fieldName]
        {
            get { return Values[fieldName]; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Values[fieldName] = fieldName;
            }
        }
    }

    //public class pr
    //{
    //    static void Main()
    //    {
    //        var t = new Category()
    //        {
    //            Id = 1, Name = "t", Parent = new Category()
    //            {
    //                Id = 2, Name = "t1", ParentId = 1, Children = new List<Category>()
    //                {
    //                    new CategoryItem()
    //                    {
    //                        Id = 1, Name = "ti", ParentId = 2, Fields = new List<CategoryField>()
    //                        {
    //                            new CategoryField()
    //                            {
    //                                Id = 45, Name = "s", Type = CategoryFieldType.Float
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        };

    //        //var s = new CatalogObject(t);
    //    }
    //}
}
