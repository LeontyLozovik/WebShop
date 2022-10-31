using AutoMapper;
using Repository.DataModels;
using WebShop.DataTransferObject;

namespace WebShop
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dto => dto.Id, obj => obj.MapFrom(x => x.Id))
                .ForMember(dto => dto.OrderStatus, obj => obj.MapFrom(x => x.OrderStatus));

            CreateMap<Customer, OrderDTO>()
                .ForMember(dto => dto.Id, obj => obj.Ignore())
                .ForMember(dto => dto.CustomerAddress, obj => obj.MapFrom(x => x.Address));

            CreateMap<Customer, FullOrderDTO>()
                .ForMember(dto => dto.Id, obj => obj.Ignore())
                .ForMember(dto => dto.CostumerAddress, obj => obj.MapFrom(x => x.Address))
                .ForMember(dto => dto.CostumerName, obj => obj.MapFrom(x => x.Name));

            CreateMap<OrderDTO, FullOrderDTO>();

            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Product, FullProductDTO>()
                .ForMember(dto => dto.ProductName, obj => obj.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<Shop, FullProductDTO>()
                .ForMember(dto => dto.Id, obj => obj.Ignore())
                .ForMember(dto => dto.ProductName, obj => obj.Ignore())
                .ForMember(dto => dto.ShopName, obj => obj.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<Product, ProductUpdateDTO>()
                .ForMember(dto => dto.ProductName, obj => obj.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<Shop, ProductUpdateDTO>()
                .ForMember(dto => dto.ShopId, obj => obj.MapFrom(x => x.Id))
                .ForMember(dto => dto.ProductName, obj => obj.Ignore())
                .ForMember(dto => dto.ShopName, obj => obj.MapFrom(x => x.Name))
                .ReverseMap();
        }
    }
}
