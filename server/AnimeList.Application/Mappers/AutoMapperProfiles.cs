using AnimeList.Data.Entities.AnimeSeries;
using AnimeList.Web.Shared.Models.AnimeSeries.Anime;
using AnimeList.Web.Shared.Models.AnimeSeries.Seasons;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Anime, AnimeListModel>();
            CreateMap<AnimeListModel, Anime>();
            CreateMap<Anime, AnimeDisplayModel>();
            CreateMap<AnimeDisplayModel, Anime>();
            CreateMap<Anime, AnimeEditRetrieveModel>();
            CreateMap<AnimeEditRetrieveModel, Anime>();


            CreateMap<Seasons, SeasonsListModel>();
            CreateMap<SeasonsListModel, Seasons>();
            CreateMap<Seasons, SeasonsDisplayModel>();
            CreateMap<SeasonsDisplayModel, Seasons>();
            CreateMap<Seasons, SeasonsEditRetrieveModel>();
            CreateMap<SeasonsEditRetrieveModel, Seasons>();
        }
    }
}
