using System;
using Xunit;

namespace IRR.Core.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var tech = new Category {Id = 1, Name = "Орг тех"};

            var pc = new CategoryItem {Id = 2, Name = "PC", Parent =  tech};
            tech.Children.Add(pc);

            var field = new CategoryField{Id = 1,Name = "cpuModel",Type = CategoryFieldType.String};
            pc.Fields.Add(field);
            //pc.Fields.Add(new CategoryField() {Id = 1,Name = "cpuModel",Type = CategoryFieldType.Int});
             
            var concretPC = new CatalogObject(pc);

            var cpu = concretPC.Values["CpuModel"]=2;

            //concreatePk.Values["CPU"] = 2.2;
        }
    }
}