using AutoMapper;
using WebApplication1.Data.Entities;
using WebApplication1.Models;
using System.Threading.Tasks;
namespace WebApplication1.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ManageUser, UserViewModel>()
                .ForMember(dst=>dst.Username, otp => otp.MapFrom(x => x.UserName));
            CreateMap<UserViewModel, ManageUser>();
        }
    }
}
