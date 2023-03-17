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
                //.ForMember(g => g.GameGenres, r => r.MapFrom(x => x.Genres.Select(rd => rd.Id)))
                //.ForMember(g => g.GameGenres, r => r.MapFrom(x => x.GameGenres.Select(rd => rd.).ToList()))
                .ReverseMap();
            CreateMap<Genre, GenreModel>()
                .ReverseMap();
            CreateMap<GameGenre, GameGenreModel>()
                .ReverseMap();
            CreateMap<Comment, CommentModel>()
                .ReverseMap();
            CreateMap<Cart, CartModel>()
                .ReverseMap();
        }
    }
}
