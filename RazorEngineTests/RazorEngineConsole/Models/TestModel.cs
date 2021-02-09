using System;
using System.Collections.Generic;
using System.Text;

namespace RazorEngineConsole.Models
{
    public class TestModel
    {
        public static TestModel CreateTestModel(string name)
        {
            return new TestModel()
            {
                Name = name,
                Items = new[] {1, 2, 3}
            };
        }

        public string Name { get; set; }
        public int[] Items { get; set; }
    }
}
