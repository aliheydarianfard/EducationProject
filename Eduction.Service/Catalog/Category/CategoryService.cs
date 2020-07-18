using System;
using System.Collections.Generic;
using System.Text;
using Eduction.Data.Repository;
using Eduction.Core.Domains;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Eduction.Service.DTOs.Category;
using Eduction.Service.Extentions;

namespace Eduction.Service.Catalog.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Eduction.Core.Domains.Category> _categoryRepository = null;

        public CategoryService(IRepository<Core.Domains.Category> repositoryCategory)
        {
			_categoryRepository = repositoryCategory;
        }
        public async Task<CategoryListItemDTO> SearchCategoryAsync(string _CategorySearchName)
        {
            CategoryListItemDTO dto = new CategoryListItemDTO();
            dto.CategorySearchName = _CategorySearchName;
            if (!string.IsNullOrEmpty(dto.CategorySearchName))
               dto.categories = await _categoryRepository.TableNoTracking.Where(p => p.Name.Contains(dto.CategorySearchName)).OrderByDescending(o => o.ID).ToListAsync();     
            else
                dto.categories = await _categoryRepository.TableNoTracking.OrderByDescending(o => o.ID).ToListAsync();          
            foreach (var i in dto.categories.ToList())
            {
                if (i.Description == null)
                {
                    i.Description = "";
                }

            }
            return dto;

        }
        public IEnumerable<Eduction.Core.Domains.Category> SearchAllCategoryAsync()
        {
            return  _categoryRepository.Table;

        }
       
        public async Task<CategoryDTO> SearchCategoryByIdAsync(int? id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var DTO = category.TODTO<CategoryDTO>();
            return DTO;

        }
        public async Task UpdateCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryDTO.ID);
            category.Name = categoryDTO.Name;
            category.Description = categoryDTO.Description;
            await _categoryRepository.UpdateAsync(category);
        }
        public async Task<bool> IsExistCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsNoTrackingAsync(id);
            if (category == null)
                return false;
            return true;
        }
        public async Task<CategoryDTO> RegisterCategoryAsync(CategoryDTO categoryDTO)
		{
			var category = categoryDTO.ToEntity<Eduction.Core.Domains.Category>();
			await _categoryRepository.InsertAsync(category);
			categoryDTO.ID = category.ID;
			return categoryDTO;
		}
        public async Task RemoveCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsNoTrackingAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }

    
    }
}
