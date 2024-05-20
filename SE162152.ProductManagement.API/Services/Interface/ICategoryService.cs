using SE162152.ProductManagement.Repo.Entity;
using System.Collections.Generic;

namespace SE162152.ProductManagement.API.Services.Interface
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        void SaveCategory(Category c);
    }
}
