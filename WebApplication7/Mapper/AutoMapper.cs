using AutoMapper;
using WebApplication7.DTOs;
using WebApplication7.Models;

namespace WebApplication7.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Category,CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        }
    }
}
