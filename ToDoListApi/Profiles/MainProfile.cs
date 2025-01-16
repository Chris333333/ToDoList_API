using AutoMapper;

namespace ToDoListApi.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Data.Entities.ToDoListDatabase.Task, Data.DTOs.TaskRetriveDTO>();
            CreateMap<Data.Entities.ToDoListDatabase.User, Data.DTOs.UserRetriveDTO>();
            CreateMap<Data.Entities.ToDoListDatabase.WorkPosition, Data.DTOs.WorkPositionRetriveDTO>();
            CreateMap<Data.Entities.ToDoListDatabase.Location, Data.DTOs.LocationRetriveDTO>();
            CreateMap<Data.Entities.ToDoListDatabase.Layout, Data.DTOs.LayoutRetriveDTO>();
        }
    }
}
