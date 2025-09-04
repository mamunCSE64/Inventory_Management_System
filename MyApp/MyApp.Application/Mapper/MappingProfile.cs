using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.DTOs;
using MyApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRoleDto, UserRole>();

            CreateMap<UserDto, User>();

            CreateMap<CategoryDto, Category>();

            CreateMap<BrandDto, Brand>();

            CreateMap<ProductDto, Product>();

            CreateMap<WarhouseDto, WarHouse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Location));

            CreateMap<SupplierDto, Supplier>();

            CreateMap<CustomerDto, Customer>();

            CreateMap<PurchaseOrderItemDto, PurchaseOrder>()
            .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SupplierId));

            CreateMap<SaleableProduct, ProductStockDto>();

            //CreateMap<supplierDTO_mapper, conveted>().ReverseMap();
            //CreateMap<supplierDTO_mapper, Supplier>().ReverseMap();
        }
    }
}
