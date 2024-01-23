using AutoMapper;
using Storage.Dto;
using Storage.Models;

namespace Storage.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StorageEntity, StorageDto>().ReverseMap();
        }
    }
}
