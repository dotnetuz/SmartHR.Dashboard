using AutoMapper;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using SmartHR.Dashboard.Domain.Entities.Users;
using SmartHR.Dashboard.Service.ViewModels.Interviews;
using SmartHR.Dashboard.Service.ViewModels.Users;

namespace SmartHR.Dashboard.Service.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Interview, InterviewViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
