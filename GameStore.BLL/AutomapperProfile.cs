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
                .ReverseMap();
            CreateMap<Genre, GenreModel>()
                .ReverseMap();
            CreateMap<GameGenre, GameGenreModel>()
                .ReverseMap();
            CreateMap<Comment, CommentModel>()
                .ReverseMap();
            
        }
    }
}
