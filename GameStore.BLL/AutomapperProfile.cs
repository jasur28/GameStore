using AutoMapper;
using GameStore.BLL.Models;
using GameStore.DAL.Entities;

namespace GameStore.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Game, GameModel>()
                .ForMember(g => g.GameGenreIds, r => r.MapFrom(x => x.GameGenre.Select(rd => rd.Id)))
                .ReverseMap();
        }
    }
}
