using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.Component.CategoryComponent
{
    public class CategoryComponent : ICategoryComponent
    {
        public Task<Category> AddNewItem(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemViewModel>> GetCategoryByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
