using AutoMapper;
using LSP.API.Models;
using Structure.BusinessObject;

namespace LSP.API.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile() 
        {
            CreateMap<ProductModel, Product>()
                .ReverseMap();
        }
    }
}
