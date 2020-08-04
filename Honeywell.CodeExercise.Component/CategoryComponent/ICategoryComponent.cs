using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.Component.CategoryComponent
{
    public interface ICategoryComponent
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int categoryId);
        Task<List<ItemViewModel>> GetCategoryByName(string name);
        Task<Category> AddNewItem(Category category);

    }
}
