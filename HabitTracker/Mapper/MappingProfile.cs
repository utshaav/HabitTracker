using AutoMapper;

namespace HabitTracker.Mapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Habit, Models.HabitDTO>().ReverseMap();
        CreateMap<Models.HabitGroup, Models.HabitGroupDTO>().ReverseMap();
        CreateMap<Models.HabitLog, Models.HabitLogDTO>().ReverseMap();
    }
}