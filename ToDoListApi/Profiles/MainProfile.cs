using AutoMapper;
using Data.Entities.ToDoListDatabase;
using Data.DTOs;

namespace ToDoListApi.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Data.Entities.ToDoListDatabase.Task,TaskRetriveDTO>();
            CreateMap<User, UserRetriveDTO>();
            CreateMap<WorkPosition, WorkPositionRetriveDTO>();
            CreateMap<Location, LocationRetriveDTO>();
            CreateMap<Layout, LayoutRetriveDTO>();

            CreateMap<LocationDTO, Location>();
            CreateMap<WorkPositionDTO, WorkPosition>();
            CreateMap<UserAddDTO, User>();
            CreateMap<LayoutAddDTO, Layout>();
            CreateMap<TaskAddDTO, Data.Entities.ToDoListDatabase.Task>();
        }
    }
}
