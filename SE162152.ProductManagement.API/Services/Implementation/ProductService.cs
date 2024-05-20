using SE162152.ProductManagement.API.Services.Interface;
using SE162152.ProductManagement.Repo.Entity;
using SE162152.ProductManagement.Repo.Repositories.Interface;

namespace SE162152.ProductManagement.API.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _productRepository;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.ProductRepository;
        }
        public List<Product> GetProducts()
        {
            try
            {
                return _productRepository.Get().ToList();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }
        public Product FindProductById(int prodId) 
        {
            try
            {
                return _productRepository.GetByID(prodId);
            }
            catch (Exception e) 
            { 
                throw new Exception(e.Message); 
            }
        }
        public void SaveProduct (Product p) 
        {
            try
            {
                _productRepository.Insert(p);
                _unitOfWork.Save();
            }
            catch (Exception e) 
            { 
                throw new Exception(e.Message); 
            }

        }
        public void UpdateProduct(Product p)
        {
            try
            {
                _productRepository.Update(p);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void DeleteProduct(Product p)
        {
            try
            {
                _productRepository.Delete(p);
                _unitOfWork.Save();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
