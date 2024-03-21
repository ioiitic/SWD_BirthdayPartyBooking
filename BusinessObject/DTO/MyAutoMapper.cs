using AutoMapper;
using BusinessObject.DTO.AccountDTO;
using BusinessObject.DTO.PlaceDTO;
using BusinessObject.DTO.RequestDTO;
using BusinessObject.DTO.ResponseDTO;
using BusinessObject.DTO.ServiceDTO;

namespace BusinessObject.DTO
{
    public class MyAutoMapper : Profile
    {
        public MyAutoMapper()
        {
            CreateMap<Account, SignInDTO>();
            CreateMap<SignUpRequest, Account>().ForMember(des => des.DeleteFlag, opt => opt.MapFrom(src => 0));
            CreateMap<Service, ServiceResponseDTO>();
            CreateMap<ServiceResponseDTO, Service>();
            CreateMap<Place, PlaceView>();
            CreateMap<PlaceView , Place>();
            CreateMap<PlaceCreateDTO, Place>();
        }
    }
}
