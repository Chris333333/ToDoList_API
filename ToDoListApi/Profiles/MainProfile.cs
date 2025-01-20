using AutoMapper;
using Data.Entities.ToDoListDatabase;
using Data.DTOs;

namespace ToDoListApi.Profiles
{
    /// <summary>
    /// Main profile for mapping entities to DTOs
    /// </summary>
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Ticket,TicketRetriveDTO>();
            CreateMap<User, UserRetriveDTO>();
            CreateMap<WorkPosition, WorkPositionRetriveDTO>();
            CreateMap<Location, LocationRetriveDTO>();
            CreateMap<Layout, LayoutRetriveDTO>();

            CreateMap<LocationDTO, Location>();
            CreateMap<WorkPositionDTO, WorkPosition>();
            CreateMap<UserAddDTO, User>();
            CreateMap<LayoutAddDTO, Layout>();
            CreateMap<TicketAddDTO, Ticket>();

            CreateMap<Comment, CommentsForTicketRetriveDTO>();
            CreateMap<CommentAddDTO, Comment>();
        }
    }
}
