using Eduction.Service.Catalog.Category;
using Eduction.Service.DTOs.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EductionWeb.Areas.Admin.Components
{
    [Area("Admin")]
    public class AdminCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService = null;

        public AdminCategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            CategoryListItemDTO dTO = new CategoryListItemDTO();
            return View(dTO);
        }
    }
}
