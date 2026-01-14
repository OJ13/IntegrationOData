using AutoMapper;
using Integration.SM.API.Domain.Entities;
using Integration.SM.API.Endpoints.DTOs;

namespace Integration.SM.API.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SalesOrder, SalesOrderDTO>().ReverseMap();

            CreateMap<SalesOrderItem, SalesOrderItemDTO>().ReverseMap();
        }
    }
}