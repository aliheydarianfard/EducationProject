using Eduction.Service.Catalog.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EductionWeb.Components
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService = null;

        public HeaderViewComponent(ICategoryService categoryService)
        {

            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke() 
        {
            var _list = _categoryService.SearchAllCategoryAsync();
            var model = new Eduction.Service.DTOs.TopMenu.TopMenu();
            foreach (var item in _list)
            {
                model.ListCategory.Add(new Eduction.Service.DTOs.TopMenu.TopMenuItemDTO { 
                CategoryName=item.Name,
                ID=item.ID
                });
            }
            return View(model);
        }
    }
}
