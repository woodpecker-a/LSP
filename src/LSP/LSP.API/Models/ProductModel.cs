using Autofac;
using AutoMapper;
using Structure.BusinessObject;
using Structure.Services;

namespace LSP.API.Models
{
    public class ProductModel
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string manufacturer { get; set; }
        public string location { get; set; }

        private IProductService _productService;
        private IMapper _mapper;

        public ProductModel() { }

        public ProductModel(IProductService service, IMapper mapper)
        {
            _productService = service;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _productService = scope.Resolve<IProductService>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal IList<Product> GetProducts() => _productService.GetAllProducts();
        internal void DeleteProduct(Guid id) => _productService.RemoveProduct(id);
        internal Product GetProduct(Guid id) => _productService.GetProduct(id);

        internal void CreateProduct()
        {
            Product product = _mapper.Map<Product>(this);
            _productService.CreateProduct(product);
        }

        internal void UpdateProduct() 
        {
            Product product = _mapper.Map<Product>(this);
            _productService.EditProduct(product);
        }

    }
}
