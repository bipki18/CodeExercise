using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.Component.SubCategoryComponent
{
    public interface ISubCategory
    {
        Task<IEnumerable<SubCategory>> GetAllSubCategory();
        Task<SubCategory> GetSubCategoryById(int categoryId);
        Task<List<ItemViewModel>> GetSubCategoryByName(string name);
        Task<SubCategory> AddNewItem(SubCategory subCategory);

    }
}
