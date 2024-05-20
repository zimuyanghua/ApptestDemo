using Apptest.Shared.Dtos;
using AutoMapper;
using AutoMapper.Configuration;
using WebApptest.Context;

namespace WebApptest.Extensions
{
    public class AutoMapperProFile : MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Dept, DeptDto>().ReverseMap();
        }
    }
}
