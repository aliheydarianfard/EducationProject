using Eduction.Service.DTOs.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eduction.Service.Catalog.Category
{
    public interface ICategoryService
    {
        Task<bool> IsExistCategoryAsync(int id);
        Task<CategoryDTO> RegisterCategoryAsync(CategoryDTO categoryDTO);
        Task RemoveCategoryAsync(int id);
        Task<CategoryListItemDTO> SearchCategoryAsync(string _CategorySearchName);
        Task<Core.Domains.Category> SearchCategoryByIdAsync(int? id);
        Task UpdateCategoryAsync(CategoryDTO categoryDTO);
    }
}