using Structure.BusinessObject;

namespace Structure.Services
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        Product GetProduct(Guid id);
        IList<Product> GetAllProducts();
        void EditProduct(Product product);
        void RemoveProduct(Guid id);
    }
}