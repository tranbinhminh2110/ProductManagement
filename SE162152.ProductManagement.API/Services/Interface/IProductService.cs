using SE162152.ProductManagement.Repo.Entity;

namespace SE162152.ProductManagement.API.Services.Interface
{
    public interface IProductService
    {
        void SaveProduct(Product p);
        Product FindProductById(int id);
        void DeleteProduct(Product p);
        void UpdateProduct(Product p);
        List<Product> GetProducts();
    }
}
