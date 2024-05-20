using SE162152.ProductManagement.API.Services.Interface;
using SE162152.ProductManagement.Repo.Entity;
using SE162152.ProductManagement.Repo.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SE162152.ProductManagement.API.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = _unitOfWork.CategoryRepository;
        }

        public List<Category> GetCategories()
        {
            try
            {
                return _categoryRepository.Get().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SaveCategory(Category c)
        {
            try
            {
                _categoryRepository.Insert(c);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
