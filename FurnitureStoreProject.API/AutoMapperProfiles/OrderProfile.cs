using AutoMapper;



namespace FurnitureStore.API.AutoMapperProfiles
{
public class OrderProfile : Profile
{
    public OrderProfile() 
    {
        // Mapeo de Order a OrderDto
        CreateMap<Entities.Order, DTOs.OrderDTOs.OrderDto>()
            .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

        // Mapeo inverso de OrderDto a Order
        CreateMap<DTOs.OrderDTOs.OrderDto, Entities.Order>();

        // Mapeo de OrderDetail a OrderDetailDto
        CreateMap<Entities.OrderDetail, DTOs.OrderDetailDTOs.OrderDetailDto>();

        // Mapeo inverso de OrderDetailDto a OrderDetail
        CreateMap<DTOs.OrderDetailDTOs.OrderDetailDto, Entities.OrderDetail>();

        // Mapeo de OrderToCreateDto a Order
        CreateMap<DTOs.OrderDTOs.OrderToCreateDto, Entities.Order>()
            .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

        // Mapeo de OrderToUpdateDto a Order
        CreateMap<DTOs.OrderDTOs.OrderToUpdateDto, Entities.Order>()
            .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
    }
}
}
