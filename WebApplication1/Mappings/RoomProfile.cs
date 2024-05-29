using AutoMapper;
using WebApplication1.Data.Entities;
using WebApplication1.Models;

namespace WebApplication1.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile ()
        {
            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomViewModel, Room>();
        }
    }
}
