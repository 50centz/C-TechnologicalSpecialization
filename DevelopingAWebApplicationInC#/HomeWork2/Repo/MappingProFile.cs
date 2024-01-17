using AutoMapper;
using HomeWork1.Models;
using HomeWork1.Models.DTO;

namespace HomeWork1.Repo
{
    public class MappingProFile : Profile
    {
        public MappingProFile() 
        {
            CreateMap<Product, ProductDto>(MemberList.Destination).ReverseMap();
            CreateMap<Category, GroupDto>(MemberList.Destination).ReverseMap();
            CreateMap<Storage, StoreDto>(MemberList.Destination).ReverseMap();
        }
    }
}
