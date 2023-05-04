using AutoMapper;
using Structure.Entities;
using BO =Structure.BusinessObject;

namespace Structure.Profiles
{
    public class StructureProfile : Profile
    {
        public StructureProfile()
        {
            CreateMap<Product, BO.Product>()
                .ReverseMap();
        }
    }
}
