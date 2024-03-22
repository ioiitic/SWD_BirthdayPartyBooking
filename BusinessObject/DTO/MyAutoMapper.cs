using AutoMapper;
using BusinessObject.DTO.AccountDTO;
using BusinessObject.DTO.PlaceDTO;
using BusinessObject.DTO.RequestDTO;
using BusinessObject.DTO.ResponseDTO;
using BusinessObject.DTO.ServiceDTO;
using System;

namespace BusinessObject.DTO
{
    public class MyAutoMapper : Profile
    {
        public MyAutoMapper()
        {
            CreateMap<Account, SignInDTO>();
            CreateMap<SignUpRequest, Account>().ForMember(des => des.DeleteFlag, opt => opt.MapFrom(src => 0));
            CreateMap<Service, ServiceResponseDTO>();
            CreateMap<Place, PlaceView>();
            CreateMap<PlaceCreateDTO, Place>();
            CreateMap<BookingRequest, Order>()
                .ForMember(des => des.OrderDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(des => des.Status, opt => opt.MapFrom(src => 0))
                .ForMember(des => des.DeleteFlag, opt => opt.MapFrom(src => 0));
            CreateMap<AccountUpdateRequest, Account>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => 0))
                .ForMember(des => des.DeleteFlag, opt => opt.MapFrom(src => 0));
            CreateMap<PlaceUpdateRequest, Place>()
                .ForMember(des => des.DeleteFlag, opt => opt.MapFrom(src => 0));
            CreateMap<ServiceUpdateRequest, Service>()
                .ForMember(des => des.DeleteFlag, opt => opt.MapFrom(src => 0));
            CreateMap<PlaceCreateDTO, Place>()
                .ForMember(des => des.DeleteFlag, opt => opt.MapFrom(src => 0));
            CreateMap<ServiceCreateRequest, Service>()
                .ForMember(des => des.DeleteFlag, opt => opt.MapFrom(src => 0));
            CreateMap<Order, OrderResponse>()
                .ForMember(des => des.HostName, opt => opt.MapFrom(src => src.Host.Name))
                .ForMember(des => des.PlaceName, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(des => des.PlaceAddress, opt => opt.MapFrom(src => src.Place.Address));
            CreateMap<OrderDetail, OrderDetailResponse>()
                .ForMember(des => des.ServiceName, opt => opt.MapFrom(src => src.Service.Name))
                .ForMember(des => des.ServiceType, opt => opt.MapFrom(src => src.Service.ServiceType.Name));
        }
    }
}
