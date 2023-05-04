using AutoMapper;
using EO = Structure.Entities;
using Structure.UnitOfWorks;
using Structure.BusinessObject;

namespace Structure.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public void CreateProduct(Product product)
        {
            EO.Product productEntity = _mapper.Map<EO.Product>(product);

            _applicationUnitOfWork.Products.Add(productEntity);
            _applicationUnitOfWork.Save();
        }

        public void EditProduct(Product product)
        {
            EO.Product productEntity = _applicationUnitOfWork.Products.GetById(product.Id);
            productEntity = _mapper.Map(product, productEntity);

            _applicationUnitOfWork.Save();
        }

        public IList<Product> GetAllProducts()
        {
            IList<EO.Product> productsEntity = _applicationUnitOfWork.Products.GetAll();
            IList<Product> products = new List<Product>();
            foreach (EO.Product p in productsEntity)
                products.Add(_mapper.Map<Product>(p));

            return products;
        }

        public Product GetProduct(Guid id)
        {
            EO.Product productEntity = _applicationUnitOfWork.Products.GetById(id);
            Product product = _mapper.Map<Product>(productEntity);
            return product;
        }

        public void RemoveProduct(Guid id)
        {
            _applicationUnitOfWork.Products.Remove(id);
            _applicationUnitOfWork.Save();
        }
    }
}
