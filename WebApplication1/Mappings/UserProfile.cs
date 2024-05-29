using AutoMapper;
using WebApplication1.Data.Entities;
using WebApplication1.Models;
namespace WebApplication1.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ManageUser, UserViewModel>()
                .ForMember(dst => dst.UserName, otp => otp.MapFrom(x => x.UserName));
            CreateMap<UserViewModel, ManageUser>();
        }
    }
}
