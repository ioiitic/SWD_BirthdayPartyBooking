using AutoMapper;
using BusinessObject.DTO.AccountDTO;
using BusinessObject.DTO.RequestDTO;

namespace BusinessObject.DTO
{
    public class MyAutoMapper : Profile
    {
        public MyAutoMapper()
        {
            CreateMap<Account, SignInDTO>();
            CreateMap<SignUpRequest, Account>().ForMember(des => des.DeleteFlag, opt => opt.MapFrom(src => 0));
        }
    }
}
