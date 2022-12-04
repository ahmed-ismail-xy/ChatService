using AutoMapper;
using CloudChatService.Core.DTOs.UserAuth;
using CloudChatService.Infrastrucure.Data;

namespace CloudChatService.API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserInfo, RegisterDTO.Request>();
            CreateMap<RegisterDTO.Request, UserInfo>();
        }
    }
}
